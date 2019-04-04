using System.Collections.Generic;
using Bhulakkad.Model;

namespace Bhulakkad.DataAccess
{
    public class LoginDetailStore
    {
        public static LoginDetailStore Current { get; } = new LoginDetailStore();
        public List<LoginDetail> LoginDetails { get; set; }

        public LoginDetailStore()
        {
            LoginDetails = new List<LoginDetail>()
            {
                new LoginDetail()
                {
                    Id = 1,
                    Site = "",
                    UserName = "",
                    Password = ""
                },
                new LoginDetail()
                {
                    Id = 1,
                    Site = "",
                    UserName = "",
                    Password = ""
                }
            };
        }
    }
}