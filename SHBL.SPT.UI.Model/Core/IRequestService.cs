using System.Threading.Tasks;

namespace SHBL.SPT.UI.Model.Core
{
    public interface IRequestService<TResponse>
    {
        Task<TResponse> ProcessRequest();
    }

    public interface IRequestService<TRequest, TResponse>
    {
        Task<TResponse> ProcessRequest(TRequest request);
    }
}
