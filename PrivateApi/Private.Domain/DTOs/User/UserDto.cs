using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.User
{
    public class UserDto
    {
        public Int64 Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
