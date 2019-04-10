using Workie.Core.Entities.Setup;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface ILanguageDB
    {
        /// <summary>
        /// Inserts a record in the Language table/collection.
        /// </summary>
        /// <param name="languageEntity"></param>
        /// <returns></returns>
        int Insert(LanguageEntity languageEntity);

        /// <summary>
        /// Deletes a record from the Language table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Selects a record from the Language table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LanguageEntity Select(int id);
    }
}
