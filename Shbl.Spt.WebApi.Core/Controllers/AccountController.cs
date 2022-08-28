using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shbl.Spt.Ui.Model.Core.Account.Requests;
using Shbl.Spt.WebApi.Core.Services.Account;

namespace Shbl.Spt.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
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
        public async Task<IActionResult> UserProfile()
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
        public async Task<IActionResult> GetAddUser()
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
        public async Task<IActionResult> UpdateProfile(UpdateProfileRequest request)
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
        public async Task<IActionResult> AddUser(AddUserRequest request)
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
