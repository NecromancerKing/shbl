using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Activities;
using System;
using System.Linq;
using System.Data.Entity;

namespace SHBL.SPT.DAL.Repository
{
    public class ActivityRepository : BaseRepository<SptContext, Activity>, IActivityRepository
    {
        
    }
}
