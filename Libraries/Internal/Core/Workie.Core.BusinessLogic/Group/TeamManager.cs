using Workie.Core.DataAccess.Database.Mongo.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.BusinessLogic.Group
{
    public class TeamManager
    {
        public string Insert(TeamEntity teamEntity)
        {
            return new TeamDB().Insert(teamEntity);
        }

        public void Delete(string id)
        {
            new TeamDB().Delete(id);
        }

        public TeamEntity SelectById(string id)
        {
            return new TeamDB().Select(id);
        }
    }
}
