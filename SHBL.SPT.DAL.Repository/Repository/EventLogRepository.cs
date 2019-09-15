using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.DAL.Repository
{
    public class EventLogRepository : BaseRepository<SptContext, EventLog>, IEventLogRepository
    {
    }
}
