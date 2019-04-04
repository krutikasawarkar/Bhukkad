using System.Collections.Generic;
using Bhulakkad.Model;

namespace Bhulakkad.DataAccess
{
    public class LoginDetailStore
    {
        public static List<LoginDetail> LoginDetailsStore { get; set; }

        public LoginDetailStore()
        {
            LoginDetailsStore = new List<LoginDetail>()
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