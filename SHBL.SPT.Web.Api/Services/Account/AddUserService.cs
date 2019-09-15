using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.UI.Model.Account.Requests;
using SHBL.SPT.UI.Model.Account.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class AddUserService : RequestServiceBase<AddUserRequest, AddUserResponse>
    {
        public override AddUserResponse ProcessRequest(AddUserRequest request)
        {
            AddUserResponse response = new AddUserResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    SptUser user = new SptUser
                    {
                        Username = request.Email,
                        Password = request.Password,
                        IsAdmin = request.IsAdmin,
                        Person = new Person
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            Gender = request.Gender,
                            AgeGroup = (Person.AgeGroupEnum)request.AgeGroup,
                            ProficiencyLevel = (Person.ProficiencyLevelEnum)request.ProficiencyLevel,
                            CFType = uow.CFTypeRepository.FindById(request.CFType)
                        }
                    };

                    uow.UserRepository.Add(user);
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