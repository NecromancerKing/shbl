using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Account.Responses;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class GetUserProfileService : RequestServiceBase<GetUserProfileResponse>
    {
        private readonly IUserService _userService;
        private readonly AuthContext _authContext;

        public GetUserProfileService(IUserService userService, AuthContext authContext)
        {
            _userService = userService;
            _authContext = authContext;
        }

        public override async Task<GetUserProfileResponse> ProcessRequest()
        {
            var user = await _userService.GetByUserNameAsync(_authContext.UserName);

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