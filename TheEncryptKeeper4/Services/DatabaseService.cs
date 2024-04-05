using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEncryptKeeper4.DataAccess;
using TheEncryptKeeper4.DataAccess.Entities;

namespace TheEncryptKeeper4.Services
{
    public class DatabaseService
    {
        LoginDBContext dbContext;

        public DatabaseService()
        {
            dbContext = new LoginDBContext();
        }

        public IList<LoginEntity> GetLoginEntities()
        {
            return dbContext.LoginEntries.ToList();
        }

        public LoginEntity CreateOrUpdateEntity(LoginEntity newLogin)
        {
            LoginEntity retVal = dbContext.LoginEntries.Add(newLogin);
            dbContext.SaveChanges();
            return retVal;
        }

    }
}
