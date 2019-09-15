using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.Auth.Requests;
using SHBL.SPT.UI.Model.Auth.Responses;
using SHBL.SPT.UI.WebApi.Services.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<RegisterService>().ProcessRequest(request);

                var AuthEndPoint = ConfigurationManager.AppSettings.Get("AuthEndPoint").ToString();
                string path = String.Format("{0}Token", AuthEndPoint);

                FormUrlEncodedContent content = new FormUrlEncodedContent(new List<KeyValuePair<String, String>>
                {
                    new KeyValuePair<String, String>("grant_type", "password"),
                    new KeyValuePair<String, String>("userName", request.Email),
                    new KeyValuePair<String, String>("password", request.Password)
                });

                return Ok(HttpClientUtility.Post<TokenResponse, ErrorResult>(path, content));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
