using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEncryptKeeper4.DataAccess.Entities
{
    public class LoginEntity
    {

        public Guid ID { get; set; }

        [NotMapped]
        public Guid PKID { get; set; }

        public string Website { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }
    }
}
