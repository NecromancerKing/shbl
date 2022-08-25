using SHBL.SPT.UI.Model.Auth.Requests;
using SHBL.SPT.UI.Model.Auth.Responses;
using SHBL.SPT.UI.WebApi.Services.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Auth")]
    public class AuthController : ApiController
    {
        private readonly RegisterService _registerService;

        public AuthController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _registerService.ProcessRequest(request);

                var authEndPoint = ConfigurationManager.AppSettings.Get("AuthEndPoint");
                var path = $"{authEndPoint}Token";

                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("userName", request.Email),
                    new KeyValuePair<string, string>("password", request.Password)
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
