using SHBL.SPT.UI.Model.Activities;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class PopulateActivityService : RequestServiceBase<PopulateActivityRequest, PopulateActivityResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly AuthContext _authContext;

        public PopulateActivityService(IUserActivityService userActivityService, AuthContext authContext)
        {
            _userActivityService = userActivityService;
            _authContext = authContext;
        }

        public override async Task<PopulateActivityResponse> ProcessRequest(PopulateActivityRequest request)
        {
            await _userActivityService.AddActivityAsync(_authContext.UserName, request.ActivityId);

            return new PopulateActivityResponse();
        }
    }
}