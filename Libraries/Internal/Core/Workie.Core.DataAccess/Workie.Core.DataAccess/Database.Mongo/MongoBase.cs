using MongoDB.Driver;

namespace Workie.Core.DataAccess.Database.Mongo
{
    public class MongoBase
    {
        private const string databaseName = "WorkieDB";

        #region Properties

        internal readonly MongoClient mongoClient;
        internal readonly IMongoDatabase mongoDatabase;

        #endregion

        #region Constructor

        internal MongoBase()
        {
            mongoClient = new MongoClient();

            // TODO: figure out a way to connect to the MongoDB using IP and credentials, even if it takes 127.0.0.1 (localhost) to do so.
            mongoDatabase = mongoClient.GetDatabase(databaseName);
        }

        #endregion
    }
}
