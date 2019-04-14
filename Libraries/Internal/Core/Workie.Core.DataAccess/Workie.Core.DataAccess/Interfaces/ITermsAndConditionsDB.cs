using Workie.Core.Entities.Legal;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface ITermsAndConditionsDB
    {
        /// <summary>
        /// Inserts a record in the TermsAndConditions table/collection.
        /// </summary>
        /// <param name="termsAndConditionsEntity"></param>
        /// <returns></returns>
        string Insert(TermsAndConditionsEntity termsAndConditions);

        /// <summary>
        /// Selects a record from the TermsAndConditions table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TermsAndConditionsEntity Select(string id);

        /// <summary>
        /// Deletes a record from the TermsAndConditions table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

    }
}