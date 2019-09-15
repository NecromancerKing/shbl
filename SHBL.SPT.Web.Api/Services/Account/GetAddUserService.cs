using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.Account.Responses;
using System;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class GetAddUserService : RequestServiceBase<GetAddUserResponse>
    {
        public override GetAddUserResponse ProcessRequest()
        {
            var response = new GetAddUserResponse();
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