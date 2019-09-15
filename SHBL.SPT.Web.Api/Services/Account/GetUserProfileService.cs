using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.UI.Model.Account.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class GetUserProfileService : RequestServiceBase<GetUserProfileResponse>
    {
        public override GetUserProfileResponse ProcessRequest()
        {
            var response = new GetUserProfileResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    string username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);
                    response.Email = user.Username;
                    response.FirstName = user.Person.FirstName;
                    response.LastName = user.Person.LastName; 
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