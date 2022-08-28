using Shbl.Spt.Model.Core.Entity.Word;

namespace Shbl.Spt.Business.Core.Interfaces
{
    public interface ICfTypeService
    {
        Task<CfType> GetByIdAsync(int id);
    }
}