using Workie.Core.Entities.Environment;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface IWebBrowserPlatformDB
    {
        /// <summary>
        /// Inserts an WebBrowserPlatform record.
        /// </summary>
        /// <param name="webBrowserPlatform"></param>
        /// <returns>Returns the index of the inserted entry.</returns>
        int Insert(WebBrowserPlatformEntity webBrowserPlatform);

        /// <summary>
        /// Selects an WebBrowserPlatform record by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the WebBrowserPlatform object.</returns>
        WebBrowserPlatformEntity Select(int id);

        /// <summary>
        /// Deletes a record from the WebBrowserPlatform table/collection.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
