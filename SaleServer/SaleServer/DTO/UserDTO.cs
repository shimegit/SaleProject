﻿namespace SaleServer.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Roles { get; set; }
    }
}
