using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEncryptKeeper4.Models
{
    public class LoginEntry
    {
        public bool IsSelected { get; set; }
        public int ID { get; set; }
        public string Website { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }

        public void ClearValues()
        {
            Website = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Notes = string.Empty;
        }

    }
}
