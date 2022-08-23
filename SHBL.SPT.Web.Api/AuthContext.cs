using Microsoft.Owin;
using Microsoft.Owin.Security;
using SHBL.SPT.BASE.Providers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;

namespace SHBL.SPT.UI.WebApi
{
    public class AuthContext : SafeSingletonProvider<AuthContext>
    {
        #region Internal Members

        internal IOwinContext OwinContext
        {
            get
            {
                return HttpContext.Current.Request.GetOwinContext();
            }
        }

        internal IAuthenticationManager AuthenticationManager
        {
            get
            {
                if (OwinContext != null)
                {
                    return OwinContext.Authentication;
                }

                return null;
            }
        }

        internal ClaimsPrincipal User
        {
            get
            {
                if (AuthenticationManager != null)
                {
                    return AuthenticationManager.User;
                }

                return null;
            }
        }

        internal HttpRequestMessage Request
        {
            get
            {
                return HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
            }
        }

        internal AuthenticationHeaderValue Authorization
        {
            get
            {
                if (Request != null)
                {
                    return Request.Headers.Authorization;
                }

                return null;
            }
        }

        #endregion

        public string AccessToken
        {
            get
            {
                if (Authorization != null)
                {
                    return Authorization.Parameter;
                }

                return null;
            }
        }

        public string UserName
        {
            get
            {
                if (User != null)
                {
                    return User.Identity.Name;
                }

                return null;
            }
        }
    }
}