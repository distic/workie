using Workie.Core.DataAccess.Database.Mongo.Setup;
using Workie.Core.Entities.Setup;

namespace Workie.Core.BusinessLogic.Setup
{
    public class CountryManager
    {
        public int Insert(CountryEntity countryEntity)
        {
            return new CountryDB().Insert(countryEntity);
        }

        public void Delete(int id)
        {
            new CountryDB().Delete(id);
        }

        public CountryEntity SelectById(int id)
        {
            return new CountryDB().Select(id);
        }
    }
}
