using Workie.Core.Entities.Setup;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface ICompanyDB
    {
        /// <summary>
        /// Inserts a record in the Company table/collection.
        /// </summary>
        /// <param name="companyEntity"></param>
        /// <returns></returns>
        string Insert(CompanyEntity companyEntity);

        /// <summary>
        /// Deletes a record from the Company table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Selects a record from the Company table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyEntity Select(string id);
    }
}
