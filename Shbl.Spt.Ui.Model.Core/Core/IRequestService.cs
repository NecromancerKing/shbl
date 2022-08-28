namespace Shbl.Spt.Ui.Model.Core.Core
{
    public interface IRequestService<TResponse>
    {
        Task<TResponse> ProcessRequest();
    }

    public interface IRequestService<in TRequest, TResponse>
    {
        Task<TResponse> ProcessRequest(TRequest request);
    }
}
