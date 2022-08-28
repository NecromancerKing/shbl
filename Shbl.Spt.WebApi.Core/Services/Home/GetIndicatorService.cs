using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.Home.Responses;

namespace Shbl.Spt.WebApi.Core.Services.Home
{
    public class GetIndicatorService : RequestServiceBase<GetIndicatorsResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly string _username;

        public GetIndicatorService(IUserActivityService userActivityService, IHttpContextAccessor httpContextAccessor)
        {
            _userActivityService = userActivityService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<GetIndicatorsResponse> ProcessRequest()
        {
            var indicators = await _userActivityService.GetIndicatorsAsync(_username);

            return new GetIndicatorsResponse { Indicators = indicators };
        }
    }
}