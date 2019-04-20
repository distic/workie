using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Database.Mongo.Group
{
    public class TeamDB : MongoBase, ITeamDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Team";

        private readonly IMongoCollection<TeamEntity> collection;

        #endregion

        #region Constructor

        public TeamDB()
        {
            collection = mongoDatabase.GetCollection<TeamEntity>(collectionName);
        }

        #endregion

        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(TeamEntity teamEntity)
        {
            #region --- Validations ---
            if (string.IsNullOrEmpty(teamEntity.Name))
            {
                return string.Empty;
            }
            #endregion

            // Manually set the known variables...
            teamEntity._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(teamEntity);

            return teamEntity._id;
        }

        public TeamEntity Select(string id)
        {
            // Lets do this without async at the moment...
            // TODO: make sure if async is necessary
            var result = collection.Find(x => x._id.Equals(id)).ToList();

            #region --- Validations ---

            if (result == null)
            {
                return null;
            }

            if (result.Count < 1)
            {
                return null;
            }

            #endregion

            return result[0];
        }
    }
}
