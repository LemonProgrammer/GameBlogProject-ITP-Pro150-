using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlogService.Models
{
    public class UserModel
    {
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfileImage { get; set; }
        public string Bio { get; set; }
    }
}
