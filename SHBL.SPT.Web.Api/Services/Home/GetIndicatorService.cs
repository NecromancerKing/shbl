using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.UI.Model.Home;
using System;
using System.Linq;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetIndicatorService : RequestServiceBase<GetIndicatorsResponse>
    {
        public override GetIndicatorsResponse ProcessRequest()
        {
            var response = new GetIndicatorsResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    var username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);
                    var userActivities = user.SptUserActivities;

                    var acts = uow.ActivityRepository.GetAll().OrderBy(t => t.ActivityOrder).ToList();
                    var last = userActivities.OrderByDescending(o => o.Activity.ActivityOrder).FirstOrDefault();
                    string ActRoute = string.Empty;
                    acts.ForEach(t =>
                    {
                        switch (t.ActivityName)
                        {
                            case "PreTest":
                                ActRoute = "app.activity.pretest";
                                break;
                            case "Training":
                                ActRoute = "app.activity.training";
                                break;
                            case "PostTest":
                                ActRoute = "app.activity.posttest";
                                break;
                        }
                        GetIndicatorsResponse.Indicator indicator = new GetIndicatorsResponse.Indicator { Route = ActRoute, Title = t.ActivityTitle };
                        if (userActivities.Where(p => p.Activity.Id == t.Id && p.FinishDate != null).Any())
                        {
                            indicator.Style = "completed";
                            indicator.IsActive = false;
                        }
                        else if (userActivities.Where(p => p.Activity.Id == t.Id && p.FinishDate == null).Any())
                        {
                            indicator.Style = "active";
                            indicator.IsActive = true;
                        }
                        else
                        {
                            if (last != null)
                            {
                                indicator.IsActive = last.FinishDate != null && last.Activity.ActivityOrder == t.ActivityOrder - 1;
                            }
                            else
                            {
                                indicator.IsActive = t.ActivityOrder == 1;
                            }
                            indicator.Style = "";
                        }
                        response.Indicators.Add(indicator);
                    });

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