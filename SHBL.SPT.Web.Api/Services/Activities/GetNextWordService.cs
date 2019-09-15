using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Word;
using SHBL.SPT.UI.Model.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class GetNextWordService : RequestServiceBase<GetNextWordRequest, GetNextWordResponse>
    {
        public override GetNextWordResponse ProcessRequest(GetNextWordRequest request)
        {
            GetNextWordResponse response = new GetNextWordResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    string username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);

                    var activity = uow.ActivityRepository.FindBy(t => t.Id == request.ActivityId && t.ActivitySession == request.Session).First();
                    var userActivityDetail = user.SptUserActivities.Where(t => t.ActivityId == activity.Id).First().SptUserActivityDetails.ToList();
                    var remainder = userActivityDetail.Where(t => t.Result == null);
                    var nextItem = remainder.OrderBy(t => t.Id).FirstOrDefault();

                    if (nextItem != null)
                    {
                        response.QNo = userActivityDetail.IndexOf(nextItem) + 1;
                        response.QCount = userActivityDetail.Count();
                        Word word = nextItem.WordSpeaker.Word;
                        response.QuestionId = nextItem.Id;
                        List<string> words = new List<string> { word.WordEntry, word.Pair.WordEntry };
                        response.Words = words.OrderBy(t => Guid.NewGuid()).ToList();
                        response.FileName = nextItem.WordSpeaker.FileName;
                    }
                    else
                    {
                        response = null;
                    } 
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}