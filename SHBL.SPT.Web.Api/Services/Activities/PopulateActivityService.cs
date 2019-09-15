using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Word;
using SHBL.SPT.UI.Model.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class PopulateActivityService : RequestServiceBase<PopulateActivityRequest, PopulateActivityResponse>
    {
        public override PopulateActivityResponse ProcessRequest(PopulateActivityRequest request)
        {
            PopulateActivityResponse response = new PopulateActivityResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    string username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);

                    var activity = uow.ActivityRepository.FindById(request.ActivityId);
                    SptUserActivity userActivity = new SptUserActivity
                    {
                        SptUser = user,
                        Activity = activity,
                        StartDate = DateTime.Now
                    };

                    var wordSpeakers = uow.WordSpeakerRepository.GetAll();
                    if (activity.IsTest)
                    {
                        wordSpeakers = wordSpeakers
                            .Where(t => t.Word.TestOnly && t.Speaker.TestOnly == false)
                            .Union(wordSpeakers.Where(t => t.Word.TestOnly == false)).OrderBy(t => Guid.NewGuid());
                        // wordSpeakers = wordSpeakers.OrderBy(t => Guid.NewGuid());
                    }
                    else
                    {
                        wordSpeakers = wordSpeakers.Where(t => t.Speaker.TestOnly == false && t.Word.TestOnly == false).OrderBy(t => Guid.NewGuid());
                    }

                    foreach (var ws in wordSpeakers)
                    {
                        userActivity.SptUserActivityDetails.Add(new SptUserActivityDetail
                        {
                            SptUserActivity = userActivity,
                            WordSpeaker = ws
                        });
                    }

                    uow.UserActivityRepository.Add(userActivity);
                    uow.Save(); 
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