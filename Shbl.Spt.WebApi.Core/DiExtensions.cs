using Shbl.Spt.WebApi.Core.Services.Account;
using Shbl.Spt.WebApi.Core.Services.Activities;
using Shbl.Spt.WebApi.Core.Services.Auth;
using Shbl.Spt.WebApi.Core.Services.Home;
using Shbl.Spt.WebApi.Core.Services.WebAuth;

namespace Shbl.Spt.WebApi.Core
{
    public static class DiExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<AddUserService>();
            services.AddScoped<GetAddUserService>();
            services.AddScoped<GetUserProfileService>();
            services.AddScoped<UpdateProfileService>();
            services.AddScoped<GetNextWordService>();
            services.AddScoped<GetTestResultService>();
            services.AddScoped<PopulateActivityService>();
            services.AddScoped<SeedDataService>();
            services.AddScoped<UpdateQuestionService>();
            services.AddScoped<RegisterService>();
            services.AddScoped<GetClientInfoService>();
            services.AddScoped<GetDashboardService>();
            services.AddScoped<GetHeaderService>();
            services.AddScoped<GetIndicatorService>();
            services.AddScoped<GetAuthHomeService>();
            services.AddScoped<GetForgetPasswordService>();
            services.AddScoped<GetLoginService>();
            services.AddScoped<GetLoginSocialService>();
            services.AddScoped<GetRegisterService>();
        }
    }
}