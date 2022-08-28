using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Activities.Request;
using Shbl.Spt.Ui.Model.Core.Activities.Response;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Activities
{
    public class PopulateActivityService : RequestServiceBase<PopulateActivityRequest, PopulateActivityResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly string _username;

        public PopulateActivityService(IUserActivityService userActivityService, IHttpContextAccessor httpContextAccessor)
        {
            _userActivityService = userActivityService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<PopulateActivityResponse> ProcessRequest(PopulateActivityRequest request)
        {
            await _userActivityService.AddActivityAsync(_username, request.ActivityId);

            return new PopulateActivityResponse();
        }
    }
}