using Workie.Core.DataAccess.Database.Mongo.Setup;
using Workie.Core.Entities.Setup;

namespace Workie.Core.BusinessLogic.Setup
{
    public class LanguageManager
    {
        public int Insert(LanguageEntity languageEntity)
        {
            return new LanguageDB().Insert(languageEntity);
        }

        public void Delete(int id)
        {
            new LanguageDB().Delete(id);
        }

        public LanguageEntity SelectById(int id)
        {
            return new LanguageDB().Select(id);
        }
    }
}
