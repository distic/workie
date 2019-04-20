using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Database.Mongo.Group
{
    public class TeamRoleDB : MongoBase, ITeamRoleDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "TeamRole";

        private readonly IMongoCollection<TeamRoleEntity> collection;

        #endregion

        #region Constructor

        public TeamRoleDB()
        {
            collection = mongoDatabase.GetCollection<TeamRoleEntity>(collectionName);
        }

        #endregion
        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(TeamRoleEntity teamRoleEntity)
        {

            // Manually set the known variables...
            teamRoleEntity._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(teamRoleEntity);

            return teamRoleEntity._id;
        }

        public TeamRoleEntity Select(string id)
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
