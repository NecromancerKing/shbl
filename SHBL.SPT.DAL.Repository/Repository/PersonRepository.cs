using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Auth;

namespace SHBL.SPT.DAL.Repository
{
    public class PersonRepository : BaseRepository<SptContext, Person>, IPersonRepository
    {
    }
}
