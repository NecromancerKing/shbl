using System.Security.Claims;
using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Account.Responses;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Account
{
    public class GetUserProfileService : RequestServiceBase<GetUserProfileResponse>
    {
        private readonly IUserService _userService;
        private readonly string _username;

        public GetUserProfileService(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _username = httpContextAccessor.HttpContext!.User!.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }

        public override async Task<GetUserProfileResponse> ProcessRequest()
        {
            var user = await _userService.GetByUserNameAsync(_username);

            var response = new GetUserProfileResponse
            {
                Email = user.Username,
                FirstName = user.Person.FirstName,
                LastName = user.Person.LastName
            };

            return response;
        }
    }
}