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
    public class GetTestResultService : RequestServiceBase<GetTestResultResponse>
    {
        public override GetTestResultResponse ProcessRequest()
        {
            GetTestResultResponse response = new GetTestResultResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    string username = AuthContext.Instance.UserName;

                    var latestActivity = uow.UserActivityRepository.FindBy(t => t.SptUser.Username == username && t.FinishDate != null).OrderByDescending(t => t.FinishDate).FirstOrDefault();
                    if (latestActivity != null)
                    {
                        if (latestActivity.Activity.IsTest)
                        {
                            response.Total = latestActivity.SptUserActivityDetails.Count();
                            response.Corrects = latestActivity.SptUserActivityDetails.Where(t => t.Result == true).Count();
                            response.Wrongs = response.Total - response.Corrects;
                        }
                        else
                        {
                            response = null;
                        }
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