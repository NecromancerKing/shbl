using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shbl.Spt.WebApi.Core.Services.WebAuth;

namespace Shbl.Spt.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    public class WebAuthController : ControllerBase
    {
        private readonly GetAuthHomeService _getAuthHomeService;
        private readonly GetLoginService _getLoginService;
        private readonly GetForgetPasswordService _getForgetPasswordService;
        private readonly GetLoginSocialService _getLoginSocialService;
        private readonly GetRegisterService _getRegisterService;

        public WebAuthController(
            GetAuthHomeService getAuthHomeService,
            GetLoginService getLoginService,
            GetForgetPasswordService getForgetPasswordService,
            GetLoginSocialService getLoginSocialService,
            GetRegisterService getRegisterService)
        {
            _getAuthHomeService = getAuthHomeService;
            _getLoginService = getLoginService;
            _getForgetPasswordService = getForgetPasswordService;
            _getLoginSocialService = getLoginSocialService;
            _getRegisterService = getRegisterService;
        }

        [HttpGet]
        [Route("AuthHome")]
        public async Task<IActionResult> AuthHome()
        {
            try
            {
                var response = await _getAuthHomeService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            try
            {
                var response = await _getLoginService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword()
        {
            try
            {
                var response = await _getForgetPasswordService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("LoginSocial")]
        public async Task<IActionResult> LoginSocial()
        {
            try
            {
                var response = await _getLoginSocialService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            try
            {
                var response = await _getRegisterService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
