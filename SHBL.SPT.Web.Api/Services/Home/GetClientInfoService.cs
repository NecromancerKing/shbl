using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Word;
using SHBL.SPT.UI.Model.Home.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetClientInfoService : RequestServiceBase<GetClientInfoResponse>
    {
        public override GetClientInfoResponse ProcessRequest()
        {
            var response = new GetClientInfoResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    string username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);
                    response.IsAdmin = user.IsAdmin;

                    var cf = user.Person.CFType;
                    int? qid = null;

                    Activity activity = new Activity();
                    var userActivities = user.SptUserActivities;

                    if (userActivities.Any())
                    {
                        var unfinished = userActivities.Where(t => t.FinishDate == null);
                        if (unfinished.Any())
                        {
                            var current = unfinished.Single();
                            activity = current.Activity;
                            qid = current.SptUserActivityDetails.Where(t => t.Result == null).OrderBy(t => t.Id).First().Id;
                            FillResponse(response, activity, cf, qid);
                        }
                        else
                        {
                            var lastFinished = userActivities.OrderByDescending(t => t.FinishDate).First();
                            //if (lastFinished.FinishDate.Value.AddDays(1) < DateTime.Now)
                            //    activity = uow.ActivityRepository.FindBy(t => t.ActivityOrder == lastFinished.Activity.ActivityOrder + 1).FirstOrDefault();
                            //else
                            //    activity = null;

                            activity = uow.ActivityRepository.FindBy(t => t.ActivityOrder == lastFinished.Activity.ActivityOrder + 1).FirstOrDefault();


                            FillResponse(response, activity, cf, null);
                        }
                    }
                    else
                    {
                        activity = uow.ActivityRepository.FindBy(t => t.ActivityOrder == 1).First();
                        FillResponse(response, activity, cf, null);
                    } 
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FillResponse(GetClientInfoResponse response, Activity activity, CFType cFType, int? qId)
        {
            response.CFTypeId = cFType.Id;
            response.CFTypeName = cFType.CFTypeName;
            if (activity == null)
            {
                response.ActivityId = null;
                response.ActivityName = null;
                response.Session = null;
                response.QuestionId = null;
                response.IsTest = null;
                response.ActivityTitle = null;
                response.ActivityDesc = null;
            }
            else
            {
                response.ActivityId = activity.Id;
                response.ActivityName = activity.ActivityName;
                response.Session = activity.ActivitySession;
                response.QuestionId = qId;
                response.IsTest = activity.IsTest;
                response.ActivityTitle = activity.ActivityTitle;
                response.ActivityDesc = activity.ActivityDesc;
            }
        }
    }
}