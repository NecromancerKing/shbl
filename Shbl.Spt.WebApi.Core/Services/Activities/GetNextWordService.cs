using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Activities.Request;
using Shbl.Spt.Ui.Model.Core.Activities.Response;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Activities
{
    public class GetNextWordService : RequestServiceBase<GetNextWordRequest, GetNextWordResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly string _username;

        public GetNextWordService(IUserActivityService userActivityService, IHttpContextAccessor httpContextAccessor)
        {
            _userActivityService = userActivityService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<GetNextWordResponse> ProcessRequest(GetNextWordRequest request)
        {
            var response = new GetNextWordResponse();
            
            var userActivityDetail = await _userActivityService.GetUserActivityDetailAsync(_username, request.ActivityId, request.Session);
            var remainder = userActivityDetail.Where(t => t.Result == null);
            var nextItem = remainder.MinBy(t => t.Id);

            if (nextItem != null)
            {
                response.QNo = userActivityDetail.IndexOf(nextItem) + 1;
                response.QCount = userActivityDetail.Count();
                var word = nextItem.WordSpeaker.Word;
                response.QuestionId = nextItem.Id;
                var words = new List<string> { word.WordEntry, word.Pair.WordEntry };
                response.Words = words.OrderBy(t => Guid.NewGuid()).ToList();
                response.FileName = nextItem.WordSpeaker.FileName;
            }
            else
            {
                response = null;
            } 

            return response;
        }
    }
}