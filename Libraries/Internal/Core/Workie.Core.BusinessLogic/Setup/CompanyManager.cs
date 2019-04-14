using Workie.Core.DataAccess.Database.Mongo.Setup;
using Workie.Core.Entities.Setup;

namespace Workie.Core.BusinessLogic.Setup
{
    public class CompanyManager
    {
        public string Insert(CompanyEntity companyEntity)
        {
            return new CompanyDB().Insert(companyEntity);
        }

        public void Delete(string id)
        {
            new CompanyDB().Delete(id);
        }

        public CompanyEntity SelectById(string id)
        {
            return new CompanyDB().Select(id);
        }
    }
}
