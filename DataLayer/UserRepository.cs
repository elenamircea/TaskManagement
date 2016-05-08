using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository
    {
        private static UserRepository singleton;

        private UserRepository()
        {

        }

        public static UserRepository getInstance()
        {
            if(singleton==null)
            {
                singleton = new UserRepository();
            }
            return singleton;
        }
        public AppUser getUser(string userId)
        {
            var db = new EntityFrameworkContext();

            AppUser userQuery = db.Users.Find(userId);
            return userQuery;
        }
    }
}
