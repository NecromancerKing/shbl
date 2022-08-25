using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Account.Requests;
using SHBL.SPT.UI.Model.Account.Responses;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class UpdateProfileService : RequestServiceBase<UpdateProfileRequest, UpdateProfileResponse>
    {
        private readonly IUserService _userService;
        private readonly AuthContext _authContext;

        public UpdateProfileService(IUserService userService, AuthContext authContext)
        {
            _userService = userService;
            _authContext = authContext;
        }

        public override async Task<UpdateProfileResponse> ProcessRequest(UpdateProfileRequest request)
        {
            await _userService.UpdateUserByUsernameAsync(_authContext.UserName, request.FirstName, request.LastName);
         
            return new UpdateProfileResponse();
        }
    }
}