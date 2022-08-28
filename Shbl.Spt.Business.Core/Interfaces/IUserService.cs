using Shbl.Spt.Model.Core.Dto;
using Shbl.Spt.Model.Core.Entity.Auth;

namespace Shbl.Spt.Business.Core.Interfaces
{
    public interface IUserService
    {
        Task<SptUser> GetByUserNameAsync(string username);

        Task<SptUser> GetByUsernameAndPasswordAsync(string username, string password);

        Task AddUserAsync(SptUser user);

        Task UpdateUserByUsernameAsync(string username, string firstName, string lastName);

        Task RegisterUserAsync(RegisterUserDto dto);
    }
}