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
        public AppUser getUser(string userId)
        {
            var db = new EntityFrameworkContext();

            AppUser userQuery = db.Users.Find(userId);
            return userQuery;
        }
    }
}
