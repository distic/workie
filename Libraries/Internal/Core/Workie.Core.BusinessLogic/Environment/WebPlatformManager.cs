using Workie.Core.DataAccess.Database.Mongo.Environment;
using Workie.Core.Entities.Environment;

namespace Workie.Core.BusinessLogic.Environment
{
    public class WebBrowserPlatformManager
    {
        public int Insert(WebBrowserPlatformEntity webBrowserPlatform)
        {
            return new WebBrowserPlatformDB().Insert(webBrowserPlatform);
        }

        public WebBrowserPlatformEntity Select(int id)
        {
            return new WebBrowserPlatformDB().Select(id);
        }

        public void Delete(int id)
        {
            new WebBrowserPlatformDB().Delete(id);
        }
    }
}
