using System.Threading.Tasks;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.Model.Dto;

namespace SHBL.SPT.Business.Interfaces
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