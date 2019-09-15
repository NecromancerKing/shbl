using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.UI.Model.Account.Requests;
using SHBL.SPT.UI.Model.Account.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class UpdateProfileService : RequestServiceBase<UpdateProfileRequest, UpdateProfileResponse>
    {
        public override UpdateProfileResponse ProcessRequest(UpdateProfileRequest request)
        {
            UpdateProfileResponse response = new UpdateProfileResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    var username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);
                    user.Person.FirstName = request.FirstName;
                    user.Person.LastName = request.LastName;
                    uow.UserRepository.Edit(user);
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