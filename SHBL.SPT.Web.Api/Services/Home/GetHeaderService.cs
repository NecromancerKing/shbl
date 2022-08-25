using SHBL.SPT.UI.Model.Home;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetHeaderService : RequestServiceBase<HeaderResponse>
    {
        private readonly IUserService _userService;
        private readonly AuthContext _authContext;

        public GetHeaderService(IUserService userService, AuthContext authContext)
        {
            _userService = userService;
            _authContext = authContext;
        }

        public override async Task<HeaderResponse> ProcessRequest()
        {
            var user = await _userService.GetByUserNameAsync(_authContext.UserName);
            var response = new HeaderResponse
            {
                Username = user.Person.FullName,
                Image = null
            };

            return response;
        }
    }
}