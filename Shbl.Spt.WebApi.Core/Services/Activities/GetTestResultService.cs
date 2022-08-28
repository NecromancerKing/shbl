using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Activities.Response;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Activities
{
    public class GetTestResultService : RequestServiceBase<GetTestResultResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly string _username;

        public GetTestResultService(IUserActivityService userActivityService, IHttpContextAccessor httpContextAccessor)
        {
            _userActivityService = userActivityService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<GetTestResultResponse> ProcessRequest()
        {
            var latestActivity = await _userActivityService.GetLatestUserActivityAsync(_username);

            if (latestActivity is null || !latestActivity.Activity.IsTest) return null;
            var response = new GetTestResultResponse
            {
                Total = latestActivity.SptUserActivityDetails.Count,
                Corrects = latestActivity.SptUserActivityDetails.Count(t => t.Result == true)
            };

            response.Wrongs = response.Total - response.Corrects;
            return response;
        }
    }
}