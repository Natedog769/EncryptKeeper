using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEncryptKeeper4.DataAccess
{
    public class LoginDBInitializer : CreateDatabaseIfNotExists<LoginDBContext>
    {
        protected override void Seed(LoginDBContext context)
        {
            base.Seed(context);
        }
    }
}
