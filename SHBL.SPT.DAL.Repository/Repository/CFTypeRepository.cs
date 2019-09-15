using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using System;
using System.Linq;
using System.Data.Entity;
using SHBL.SPT.Model.Word;

namespace SHBL.SPT.DAL.Repository
{
    public class CFTypeRepository : BaseRepository<SptContext, CFType>, ICFTypeRepository
    {
        
    }
}
