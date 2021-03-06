﻿using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Setup;

namespace Workie.Core.DataAccess.Database.Mongo.Setup
{
    public class CompanyDB : MongoBase, ICompanyDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Company";

        private readonly IMongoCollection<CompanyEntity> collection;

        #endregion

        #region Constructor

        public CompanyDB()
        {
            collection = mongoDatabase.GetCollection<CompanyEntity>(collectionName);
        }

        #endregion

        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(CompanyEntity companyEntity)
        {
            #region --- Validations ---

            if (string.IsNullOrEmpty(companyEntity.Name))
            {
                return string.Empty;
            }

            #endregion

            // Manually set the known variables...
            companyEntity._id = ObjectId.GenerateNewId().ToString();
            
            // Lets keep things simple and avoid await for now..
            collection.InsertOne(companyEntity);

            return companyEntity._id;
        }

        public CompanyEntity Select(string id)
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
