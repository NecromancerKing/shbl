using SHBL.SPT.UI.Model.Account.Requests;
using SHBL.SPT.UI.WebApi.Services.Account;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        private readonly GetUserProfileService _getUserProfileService;
        private readonly GetAddUserService _getAddUserService;
        private readonly UpdateProfileService _updateProfileService;
        private readonly AddUserService _addUserService;

        public AccountController(
            GetUserProfileService getUserProfileService, 
            GetAddUserService getAddUserService,
            UpdateProfileService updateProfileService, 
            AddUserService addUserService)
        {
            _getUserProfileService = getUserProfileService;
            _getAddUserService = getAddUserService;
            _updateProfileService = updateProfileService;
            _addUserService = addUserService;
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile")]
        public async Task<IHttpActionResult> UserProfile()
        {
            try
            {
                var response = await _getUserProfileService.ProcessRequest();
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
        public async Task<IHttpActionResult> GetAddUser()
        {
            try
            {
                var response = await _getAddUserService.ProcessRequest();
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
        public async Task<IHttpActionResult> UpdateProfile(UpdateProfileRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _updateProfileService.ProcessRequest(request);
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
        public async Task<IHttpActionResult> AddUser(AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _addUserService.ProcessRequest(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
