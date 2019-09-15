using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;
using System;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetForgetPasswordService : RequestServiceBase<GetForgetPasswordResponse>
    {
        public override GetForgetPasswordResponse ProcessRequest()
        {
            var response = new GetForgetPasswordResponse();
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