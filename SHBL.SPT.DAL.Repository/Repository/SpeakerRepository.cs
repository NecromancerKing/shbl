﻿using SHBL.SPT.BASE.Repository;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Word;

namespace SHBL.SPT.DAL.Repository
{
    public class SpeakerRepository : BaseRepository<SptContext, Speaker>, ISpeakerRepository
    {
        
    }
}
