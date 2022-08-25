using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;

namespace SHBL.SPT.UI.WebApi
{
    public class AuthContext
    {
        internal IOwinContext OwinContext => HttpContext.Current.Request.GetOwinContext();

        internal IAuthenticationManager AuthenticationManager => OwinContext?.Authentication;

        internal ClaimsPrincipal User => AuthenticationManager?.User;

        internal HttpRequestMessage Request => HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;

        internal AuthenticationHeaderValue Authorization => Request?.Headers.Authorization;

        public string AccessToken => Authorization?.Parameter;

        public string UserName => User?.Identity.Name;
    }
}