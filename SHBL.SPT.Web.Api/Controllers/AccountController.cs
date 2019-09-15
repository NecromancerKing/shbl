using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.Account.Requests;
using SHBL.SPT.UI.WebApi.Services.Account;
using System;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("UserProfile")]
        public IHttpActionResult UserProfile()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetUserProfileService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetAddUser")]
        public IHttpActionResult GetAddUser()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetAddUserService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateProfile")]
        public IHttpActionResult UpdateProfile(UpdateProfileRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<UpdateProfileService>().ProcessRequest(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("AddUser")]
        public IHttpActionResult AddUser(AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<AddUserService>().ProcessRequest(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
