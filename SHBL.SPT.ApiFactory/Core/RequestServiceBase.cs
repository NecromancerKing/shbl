using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.ApiFactory.Core
{
    public abstract class RequestServiceBase
    {
    }

    public abstract class RequestServiceBase<TResponse> : RequestServiceBase, IRequestService<TResponse>
        where TResponse : ResponseBase
    {
        public abstract TResponse ProcessRequest();
    }

    public abstract class RequestServiceBase<TRequest, TResponse>: RequestServiceBase, IRequestService<TRequest, TResponse>
        where TRequest: RequestBase
        where TResponse:ResponseBase
        
    {
        public abstract TResponse ProcessRequest(TRequest request);
    }
}
