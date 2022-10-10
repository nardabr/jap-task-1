using System.ComponentModel.DataAnnotations;

namespace jap_task.Dtos.User
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
