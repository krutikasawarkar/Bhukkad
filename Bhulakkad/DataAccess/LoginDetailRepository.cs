using System.Collections.Generic;
using Bhulakkad.Model;

namespace Bhulakkad.DataAccess
{
    public class LoginDetailRepository : ILoginDetailRepository
    {
        public List<LoginDetail> GetLoginDetails()
        {
            return LoginDetailStore.Current.LoginDetails;
        }
    }
}