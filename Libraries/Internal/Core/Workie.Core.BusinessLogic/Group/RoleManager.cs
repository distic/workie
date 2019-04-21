using Workie.Core.DataAccess.Database.Mongo.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.BusinessLogic.Group
{
    public class RoleManager
    {
        public string Insert(RoleEntity roleEntity)
        {
            return new RoleDB().Insert(roleEntity);
        }

        public void Delete(string id)
        {
            new RoleDB().Delete(id);
        }

        public RoleEntity SelectById(string id)
        {
            return new RoleDB().Select(id);
        }


    }
}
