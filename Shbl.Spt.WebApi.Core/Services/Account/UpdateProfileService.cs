using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Account.Requests;
using Shbl.Spt.Ui.Model.Core.Account.Responses;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Account
{
    public class UpdateProfileService : RequestServiceBase<UpdateProfileRequest, UpdateProfileResponse>
    {
        private readonly IUserService _userService;
        private readonly string _username;

        public UpdateProfileService(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<UpdateProfileResponse> ProcessRequest(UpdateProfileRequest request)
        {
            await _userService.UpdateUserByUsernameAsync(_username, request.FirstName, request.LastName);
         
            return new UpdateProfileResponse();
        }
    }
}