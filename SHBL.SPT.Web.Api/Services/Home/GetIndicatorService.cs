using SHBL.SPT.UI.Model.Home;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetIndicatorService : RequestServiceBase<GetIndicatorsResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly AuthContext _authContext;

        public GetIndicatorService(IUserActivityService userActivityService, AuthContext authContext)
        {
            _userActivityService = userActivityService;
            _authContext = authContext;
        }

        public override async Task<GetIndicatorsResponse> ProcessRequest()
        {
            var indicators = await _userActivityService.GetIndicatorsAsync(_authContext.UserName);

            return new GetIndicatorsResponse { Indicators = indicators };
        }
    }
}