using System;
using System.Collections.Generic;
using System.Text;
using Workie.Core.DataAccess.Database.Mongo.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.BusinessLogic.Group
{
    public class PermissionManager
    {
        public string Insert(PermissionEntity permissionEntity)
        {
            return new PermissionDB().Insert(permissionEntity);
        }

        public void Delete(string id)
        {
            new PermissionDB().Delete(id);
        }

        public PermissionEntity SelectById(string id)
        {
            return new PermissionDB().Select(id);
        }
    }
}
