using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;

namespace SHBL.SPT.UI.WebApi
{
    public class ApplicationAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserService _userService;

        public ApplicationAuthorizationServerProvider(IUserService userService)
        {
            _userService = userService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            await Task.CompletedTask;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await _userService.GetByUsernameAndPasswordAsync(context.UserName, context.Password);

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
}