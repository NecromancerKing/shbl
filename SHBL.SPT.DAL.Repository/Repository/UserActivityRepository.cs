using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Activities;

namespace SHBL.SPT.DAL.Repository
{
    public class UserActivityRepository : BaseRepository<SptContext, SptUserActivity>, IUserActivityRepository
    {
        
    }
}
