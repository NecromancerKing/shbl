using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Core
{
    public abstract class RequestServiceBase
    {
    }

    public abstract class RequestServiceBase<TResponse> : RequestServiceBase, IRequestService<TResponse>
        where TResponse : ResponseBase
    {
        public abstract Task<TResponse> ProcessRequest();
    }

    public abstract class RequestServiceBase<TRequest, TResponse>: RequestServiceBase, IRequestService<TRequest, TResponse>
        where TRequest: RequestBase
        where TResponse:ResponseBase
        
    {
        public abstract Task<TResponse> ProcessRequest(TRequest request);
    }
}
