
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.DTOs
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
