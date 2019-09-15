namespace SHBL.SPT.ApiFactory.Core
{
    public interface IRequestService<TResponse>
    {
        TResponse ProcessRequest();
    }

    public interface IRequestService<TRequest, TResponse>
    {
        TResponse ProcessRequest(TRequest request);
    }
}
