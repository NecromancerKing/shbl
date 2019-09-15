using Microsoft.Owin.Security.OAuth;
using SHBL.SPT.Business;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SHBL.SPT.UI.WebApi
{
    public class ApplicationAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    var user = uow.UserRepository.FindBy(w => w.Username == context.UserName && w.Password == context.Password).FirstOrDefault();

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The username or password is incorrect.");
                        context.Rejected();
                        return;
                    }

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    identity.AddClaim(new Claim("Username", user.Username));
                    identity.AddClaim(new Claim("FullName", user.Person.FullName));
                    context.Validated(identity); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}