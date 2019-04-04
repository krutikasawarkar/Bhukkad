using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bhulakkad.DataAccess;
using Bhulakkad.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bhulakkad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDetailController : Controller
    {
        private readonly ILoginDetailRepository _loginDetailRepository;

        public LoginDetailController(ILoginDetailRepository loginDetailRepository)
        {
            _loginDetailRepository = loginDetailRepository;
        }

        [HttpGet]
        public ActionResult<List<LoginDetail>> Get()
        {
            return _loginDetailRepository.GetLoginDetails();
        }

        [HttpPost("CreateLoginDetail")]
        public OkResult CreateLoginDetail(
            [FromBody] LoginDetail login)
        {
            var maxId = _loginDetailRepository.GetLoginDetails().Max(x => x.Id);
            var finalLoginDetail = new LoginDetail()
            {
                Id = ++maxId,
                Site = login.Site,
                UserName = login.UserName,
                Password = login.Password
            };

            LoginDetailStore.LoginDetailsStore.Add(finalLoginDetail);

            return Ok();
        }
    }
}