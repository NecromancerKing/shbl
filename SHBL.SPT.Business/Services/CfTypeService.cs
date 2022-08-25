using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.Model.Word;

namespace SHBL.SPT.Business.Services
{
    public class CfTypeService : ICfTypeService
    {
        private readonly SptContext _context;

        public CfTypeService()
        {
            _context = new SptContext();
        }

        public async Task<CFType> GetByIdAsync(int id)
        {
            return await _context.CFTypes.FindAsync(id);
        }
    }
}