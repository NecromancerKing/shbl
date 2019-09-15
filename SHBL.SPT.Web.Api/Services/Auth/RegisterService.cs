using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.UI.Model.Auth.Requests;
using SHBL.SPT.UI.Model.Auth.Responses;
using SHBL.SPT.UI.WebApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Auth
{
    public class RegisterService : RequestServiceBase<RegisterRequest, RegisterResponse>
    {
        public override RegisterResponse ProcessRequest(RegisterRequest request)
        {
            var uow = new SptUnitOfWork();
            RegisterResponse response = new RegisterResponse();
            try
            {
                if (uow.UserRepository.FindBy(t => t.Username == request.Email).Any())
                {
                    throw new Exception("Email address is not available!");
                }

                var cfs =
                    from c in uow.CFTypeRepository.GetAll()
                    join p in uow.PersonRepository.FindBy(t => t.AgeGroup == (Person.AgeGroupEnum)request.AgeGroup && t.ProficiencyLevel == (Person.ProficiencyLevelEnum)request.ProficiencyLevel) on c.Id equals p.CFType.Id into ps
                    from q in ps.DefaultIfEmpty()
                    select new { cf = c, cnt = q.CFType != null ? ps.Count(t => t.CFType.Id == c.Id) : 0 };

                var next = cfs.OrderBy(t => t.cnt).ThenBy(t => t.cf.Id).First().cf;

                SptUser user = new SptUser
                {
                    Username = request.Email,
                    Password = request.Password,
                    IsAdmin = false,
                    Person = new Person
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Gender = request.Gender,
                        AgeGroup = (Person.AgeGroupEnum)request.AgeGroup,
                        ProficiencyLevel = (Person.ProficiencyLevelEnum)request.ProficiencyLevel,
                        CFType = next
                    }
                };

                uow.UserRepository.Add(user);
                uow.Save();
                uow.Dispose();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Dear {0},");
                    sb.Append("\n\nThank you for registering for the Oratio speech perception training.");
                    sb.Append("\n\n\tYour username : {1}");
                    sb.Append("\n\tYour password : {2}");
                    sb.Append("\n\nYou can sign in and start using your credentials straight away.");
                    sb.Append("\nIf you have any questions please contact support at oratio.spt@gmail.com.");
                    sb.Append("\n\nBest regards,");
                    sb.Append("\nOratio");
                    sb.Append("\n[" + DateTime.Now + "]");

                    string body = string.Format(sb.ToString(), request.FirstName, request.Email, request.Password);
                    // MailHleper.Instance.SendMail(request.Email, "Welcome to Oratio!", body);
                }
                catch (Exception) {}

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}