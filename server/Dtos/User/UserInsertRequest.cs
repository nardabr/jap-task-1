﻿namespace jap_task.Dtos.User
{
    public class UserInsertRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
    }
}
