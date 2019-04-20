using Workie.Core.DataAccess.Database.Mongo.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.BusinessLogic.Group
{
    public class TeamRoleManager
    {
        public string Insert(TeamRoleEntity teamRoleEntity)
        {
            return new TeamRoleDB().Insert(teamRoleEntity);
        }

        public void Delete(string id)
        {
            new TeamRoleDB().Delete(id);
        }

        public TeamRoleEntity SelectById(string id)
        {
            return new TeamRoleDB().Select(id);
        }
    }
}
