using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Dal.Core.Context;
using Shbl.Spt.Model.Core.Entity.Word;

namespace Shbl.Spt.Business.Core.Services
{
    internal class CfTypeService : ICfTypeService
    {
        private readonly SptContext _context;

        public CfTypeService(SptContext context)
        {
            _context = context;
        }

        public async Task<CfType> GetByIdAsync(int id)
        {
            return await _context.CfTypes.FindAsync(id);
        }
    }
}