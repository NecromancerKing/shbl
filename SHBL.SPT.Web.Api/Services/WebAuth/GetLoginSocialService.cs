using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetLoginSocialService : RequestServiceBase<GetLoginSocialResponse>
    {
        public override GetLoginSocialResponse ProcessRequest()
        {
            var response = new GetLoginSocialResponse();
            try
            {
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}