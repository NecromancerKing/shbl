using SHBL.SPT.UI.Model.Auth.Requests;
using SHBL.SPT.UI.Model.Auth.Responses;
using System;
using System.Text;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.Model.Dto;
using SHBL.SPT.UI.Model.Core;
using SHBL.SPT.UI.WebApi.Helper;

namespace SHBL.SPT.UI.WebApi.Services.Auth
{
    public class RegisterService : RequestServiceBase<RegisterRequest, RegisterResponse>
    {
        private readonly IUserService _userService;

        public RegisterService(IUserService userService)
        {
            _userService = userService;
        }

        public override async Task<RegisterResponse> ProcessRequest(RegisterRequest request)
        {
            var dto = new RegisterUserDto
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                AgeGroup = request.AgeGroup,
                ProficiencyLevel = request.ProficiencyLevel
            };

            await _userService.RegisterUserAsync(dto);

            try
            {
                var sb = new StringBuilder();
                sb.Append("Dear {0},");
                sb.Append("\n\nThank you for registering for the Oratio speech perception training.");
                sb.Append("\n\n\tYour username : {1}");
                sb.Append("\n\tYour password : {2}");
                sb.Append("\n\nYou can sign in and start using your credentials straight away.");
                sb.Append("\nIf you have any questions please contact support at oratio.spt@gmail.com.");
                sb.Append("\n\nBest regards,");
                sb.Append("\nOratio");
                sb.Append("\n[" + DateTime.Now + "]");

                var body = string.Format(sb.ToString(), request.FirstName, request.Email, request.Password);
                MailHelper.SendMail(request.Email, "Welcome to Oratio!", body);
            }
            catch
            {
                // ignored
            }

            return new RegisterResponse();
        }
    }
}