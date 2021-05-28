using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }

    }
}
