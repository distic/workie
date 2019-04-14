using System;
using Workie.Core.DataAccess.Database.Mongo.Environment;
using Workie.Core.Entities.Environment;

namespace Workie.Core.BusinessLogic.Environment
{
    public class OSPlatformManager
    {
        public int Insert(OSPlatformEntity osPlatform)
        {
            return new OSPlatformDB().Insert(osPlatform);
        }

        public OSPlatformEntity Select(int id)
        {
            return new OSPlatformDB().Select(id);
        }

        public void Delete(int id)
        {
            new OSPlatformDB().Delete(id);
        }
    }
}
