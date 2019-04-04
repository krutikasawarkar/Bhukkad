using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bhulakkad.DataAccess;
using Bhulakkad.Model;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult CreateLoginDetail(
            [FromBody] LoginDetail loginDetail)
        {
            if (loginDetail == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var maxId = _loginDetailRepository.GetLoginDetails().Max(x => x.Id);
            var finalLoginDetail = new LoginDetail()
            {
                Id = ++maxId,
                Site = loginDetail.Site,
                UserName = loginDetail.UserName,
                Password = loginDetail.Password
            };

            LoginDetailStore.Current.LoginDetails.Add(finalLoginDetail);

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] LoginDetail loginDetail)
        {
            if (loginDetail == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logindetailForUpdate = LoginDetailStore.Current.LoginDetails.FirstOrDefault(
                loginInfo => loginInfo.Site == loginDetail.Site);

            LoginDetailStore.Current.LoginDetails.Add(logindetailForUpdate);

            return NoContent();
        }

        public ActionResult PartiallyUpdateLoginDetails(int id,
            [FromBody] JsonPatchDocument<LoginDetail> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var loginDetailForUpdate = LoginDetailStore.Current.LoginDetails.FirstOrDefault(
                loginInfo => loginInfo.Id == id);

            if (loginDetailForUpdate == null)
            {
                return BadRequest();
            }

            var loginDetailToPatch =
                new LoginDetail()
                {
                    Id = loginDetailForUpdate.Id,
                    Site = loginDetailForUpdate.Site,
                    UserName =  loginDetailForUpdate.UserName,
                    Password =  loginDetailForUpdate.Password
                };

            patchDoc.ApplyTo(loginDetailToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}