using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.General;

namespace SHBL.SPT.DAL.Repository
{
    public class EventLogRepository : BaseRepository<SptContext, EventLog>, IEventLogRepository
    {
    }
}
