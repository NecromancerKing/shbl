using SHBL.SPT.UI.Model.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class GetNextWordService : RequestServiceBase<GetNextWordRequest, GetNextWordResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly AuthContext _authContext;

        public GetNextWordService(IUserActivityService userActivityService, AuthContext authContext)
        {
            _userActivityService = userActivityService;
            _authContext = authContext;
        }

        public override async Task<GetNextWordResponse> ProcessRequest(GetNextWordRequest request)
        {
            var response = new GetNextWordResponse();
            
            var userActivityDetail = await _userActivityService.GetUserActivityDetailAsync(_authContext.UserName, request.ActivityId, request.Session);
            var remainder = userActivityDetail.Where(t => t.Result == null);
            var nextItem = remainder.OrderBy(t => t.Id).FirstOrDefault();

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