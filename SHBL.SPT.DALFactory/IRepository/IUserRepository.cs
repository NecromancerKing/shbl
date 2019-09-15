using SHBL.SPT.BASE.Repository;
using SHBL.SPT.Model.Auth;

namespace SHBL.SPT.DALFactory
{
    public interface IUserRepository : IRepository<SptUser>
    {
        SptUser GetByUserName(string username);
    }
}
