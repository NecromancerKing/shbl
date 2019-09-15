using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.WebAuth;
using SHBL.SPT.UI.WebApi.Services.WebAuth;
using System;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("WebAuth")]
    public class WebAuthController : ApiController
    {
        [HttpGet]
        [Route("AuthHome")]
        public IHttpActionResult AuthHome()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetAuthHomeService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Login")]
        public IHttpActionResult Login()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetLoginService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ForgetPassword")]
        public IHttpActionResult ForgetPassword()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetForgetPasswordService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("LoginSocial")]
        public IHttpActionResult LoginSocial()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetLoginSocialService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Register")]
        public IHttpActionResult Register()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetRegisterService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
