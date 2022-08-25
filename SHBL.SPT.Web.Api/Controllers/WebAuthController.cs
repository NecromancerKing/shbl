using SHBL.SPT.UI.WebApi.Services.WebAuth;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("WebAuth")]
    public class WebAuthController : ApiController
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
        public async Task<IHttpActionResult> AuthHome()
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

        [HttpGet]
        [Route("Login")]
        public async Task<IHttpActionResult> Login()
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
        public async Task<IHttpActionResult> ForgetPassword()
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
        public async Task<IHttpActionResult> LoginSocial()
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
        public async Task<IHttpActionResult> Register()
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
