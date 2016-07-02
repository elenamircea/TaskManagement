using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TeamRepository
    {
        private static TeamRepository singleton;

        private TeamRepository()
        {

        }

        public static TeamRepository getInstance()
        {
            if (singleton == null)
            {
                singleton = new TeamRepository();
            }
            return singleton;
        }
        public Team getTeamForUser(string userId)
        {
            UserRepository userRepository = UserRepository.getInstance();
            var user=userRepository.getUser(userId);

            if (user.TeamId == null)
            {
                return null;
            }
            else
            {
                var db = new EntityFrameworkContext();
                var teamQuery = (from team in db.TeamList.Include("TeamMembers")
                                 where team.Id == user.TeamId
                                 select team).FirstOrDefault();
                var teamLeaderUser = db.Users.Find(teamQuery.TeamLeaderUserId);
                teamQuery.TeamLeaderEmail = teamLeaderUser.UserName;
                return teamQuery;
            }
        }

        public void create(string userId, Team team)
        {
            EntityFrameworkContext db;

            using (db = new EntityFrameworkContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        team.TeamLeaderUserId = userId;
                        db.TeamList.Add(team);
                        db.SaveChanges();

                        var user = db.Users.Find(userId);
                        user.TeamId = team.Id;

                        db.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void edit(Team updatedTeam)
        {
            var db = new EntityFrameworkContext();
            var original = db.TeamList.Find(updatedTeam.Id);

            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(updatedTeam);
                db.SaveChanges();
            }
        }

        public Team search(int id)
        {
            var db = new EntityFrameworkContext();
            var original = db.TeamList.Find(id);
            
            return original;
        }
    }
}
