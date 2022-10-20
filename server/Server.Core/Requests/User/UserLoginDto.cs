using System.ComponentModel.DataAnnotations;

namespace Server.Core.Requests.User
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
