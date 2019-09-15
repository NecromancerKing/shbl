using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Auth;
using System;
using System.Data.Entity;
using System.Linq;

namespace SHBL.SPT.DAL.Repository
{
    public class UserRepository : BaseRepository<SptContext, SptUser>, IUserRepository
    {        
        public SptUser GetByUserName(string username)
        {
            try
            {
                SptUser user = Context.SptUsers.Where(t => t.Username == username).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
