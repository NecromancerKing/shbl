using System.Linq;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Activities;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class GetTestResultService : RequestServiceBase<GetTestResultResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly AuthContext _authContext;

        public GetTestResultService(IUserActivityService userActivityService, AuthContext authContext)
        {
            _userActivityService = userActivityService;
            _authContext = authContext;
        }

        public override async Task<GetTestResultResponse> ProcessRequest()
        {
            var latestActivity = await _userActivityService.GetLatestUserActivityAsync(_authContext.UserName);

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