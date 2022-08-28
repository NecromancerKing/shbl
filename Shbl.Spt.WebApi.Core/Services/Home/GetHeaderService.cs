using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.Home.Responses;

namespace Shbl.Spt.WebApi.Core.Services.Home
{
    public class GetHeaderService : RequestServiceBase<HeaderResponse>
    {
        private readonly IUserService _userService;
        private readonly string _username;

        public GetHeaderService(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<HeaderResponse> ProcessRequest()
        {
            var user = await _userService.GetByUserNameAsync(_username);
            var response = new HeaderResponse
            {
                Username = user.Person.FullName,
                Image = null
            };

            return response;
        }
    }
}