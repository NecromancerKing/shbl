using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Auth;
using System.Linq;

namespace SHBL.SPT.DAL.Repository
{
    public class UserRepository : BaseRepository<SptContext, SptUser>, IUserRepository
    {        
        public SptUser GetByUserName(string username)
        {
            return Context.SptUsers.FirstOrDefault(t => t.Username == username);
        }
    }
}
