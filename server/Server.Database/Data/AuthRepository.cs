using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Core.Entities;
using Server.Core.Requests.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Database.Data

{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthRepository(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration, 
            IMapper mapper) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<dynamic> Login(UserLoginDto req)
        {
            var user = await _userManager.FindByEmailAsync(req.Email);
            if (user == null) throw new Exception("Nije dobar user");

            var goodPassword = await _userManager.CheckPasswordAsync(user, req.Password);
            if (goodPassword == false) throw new Exception("Nije dobar password");

            if (user != null && goodPassword != false)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var token = GetToken(authClaims);

                return new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    userId = user.Id,
                    role = userRoles[0]
                };
            }

            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<User> InsertUser(UserInsertRequest insert)
        {

            var user = _mapper.Map<User>(insert);
        
            var res = await _userManager.CreateAsync(user, insert.Password);
            if (!res.Succeeded)
                throw new Exception("User was not added.");

            var role = await _roleManager.FindByIdAsync(insert.RoleId.ToString());
            if (role == null)
                throw new Exception("Role was not found.");

            await _userManager.AddToRoleAsync(user, role.Name);

            return _mapper.Map<User>(user);
        }
    }
}