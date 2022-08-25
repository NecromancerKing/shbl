using System.Threading.Tasks;
using SHBL.SPT.Model.Word;

namespace SHBL.SPT.Business.Interfaces
{
    public interface ICfTypeService
    {
        Task<CFType> GetByIdAsync(int id);
    }
}