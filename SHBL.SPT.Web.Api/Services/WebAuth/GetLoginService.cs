using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;
using System;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetLoginService : RequestServiceBase<GetLoginResponse>
    {
        public override GetLoginResponse ProcessRequest()
        {
            var response = new GetLoginResponse();
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