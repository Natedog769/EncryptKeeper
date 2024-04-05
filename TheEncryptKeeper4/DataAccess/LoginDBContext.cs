using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEncryptKeeper4.DataAccess.Entities;
using TheEncryptKeeper4.Models;

namespace TheEncryptKeeper4.DataAccess
{
    public class LoginDBContext : DbContext
    {
        public DbSet<LoginEntity> LoginEntries { get; set; }

        public LoginDBContext() : base("LoginDBContext")
        {
            Database.SetInitializer(new LoginDBInitializer());
        }
        
    }
}
