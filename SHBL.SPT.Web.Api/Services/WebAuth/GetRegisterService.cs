using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetRegisterService : RequestServiceBase<GetRegisterResponse>
    {
        public override GetRegisterResponse ProcessRequest()
        {
            var response = new GetRegisterResponse();
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