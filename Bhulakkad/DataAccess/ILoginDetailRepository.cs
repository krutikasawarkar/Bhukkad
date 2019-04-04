using System.Collections.Generic;
using Bhulakkad.Model;

namespace Bhulakkad.DataAccess
{
    public interface ILoginDetailRepository
    {
        List<LoginDetail> GetLoginDetails();
    }
}