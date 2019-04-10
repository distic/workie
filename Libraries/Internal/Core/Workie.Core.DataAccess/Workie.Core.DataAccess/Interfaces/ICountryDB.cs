using Workie.Core.Entities.Setup;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface ICountryDB
    {
        /// <summary>
        /// Inserts a record in the Country table/collection.
        /// </summary>
        /// <param name="countryEntity"></param>
        /// <returns></returns>
        int Insert(CountryEntity countryEntity);

        /// <summary>
        /// Deletes a record from the Country table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Selects a record from the Country table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CountryEntity Select(int id);
    }
}
