using Workie.Core.DataAccess.Database.Mongo.Legal;
using Workie.Core.Entities.Legal;

namespace Workie.Core.BusinessLogic.Legal
{
    public class TermsAndConditionsManager
    {
        public string Insert(TermsAndConditionsEntity termsAndConditions)
        {
            return new TermsAndConditionsDB().Insert(termsAndConditions);
        }

        public TermsAndConditionsEntity Select(string id)
        {
            return new TermsAndConditionsDB().Select(id);
        }

        public void Delete(string id)
        {
            new TermsAndConditionsDB().Delete(id);
        }
    }
}
