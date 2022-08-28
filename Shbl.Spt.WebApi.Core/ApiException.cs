using System.Reflection;
using Newtonsoft.Json;

namespace Shbl.Spt.WebApi.Core
{
    public class ApiException : ExceptionBase
    {
        #region Constructors

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception inner) : base(message, inner)
        {
        }

        public ApiException(string message, string applicationCode, MethodBase methodBase) : base(message, applicationCode, methodBase)
        {
        }

        public ApiException(string message, string applicationCode, string className, string methodName) : base(message, applicationCode, className, methodName)
        {
        }

        public ApiException(string message, Exception inner, string applicationCode, MethodBase methodBase) : base(message, inner, applicationCode, methodBase)
        {
        }

        public ApiException(string message, Exception inner, string applicationCode, string className, string methodName) : base(message, inner, applicationCode, className, methodName)
        {
        }

        #endregion
    }

    public class ApiException<T> : ApiException
    {
        #region Constructor

        public ApiException(string message, string json)
            : base(message)
        {
            this.ErrorResult = JsonConvert.DeserializeObject<T>(json);
        }

        #endregion

        #region Properties

        public T ErrorResult { get; set; }

        #endregion
    }

    public class UnauthorizedApiException : ApiException
    {
        public UnauthorizedApiException()
        {
        }

        public UnauthorizedApiException(string message) : base(message)
        {
        }

        public UnauthorizedApiException(string message, Exception inner) : base(message, inner)
        {
        }

        public UnauthorizedApiException(string message, string applicationCode, MethodBase methodBase) : base(message, applicationCode, methodBase)
        {
        }

        public UnauthorizedApiException(string message, string applicationCode, string className, string methodName) : base(message, applicationCode, className, methodName)
        {
        }

        public UnauthorizedApiException(string message, Exception inner, string applicationCode, MethodBase methodBase) : base(message, inner, applicationCode, methodBase)
        {
        }

        public UnauthorizedApiException(string message, Exception inner, string applicationCode, string className, string methodName) : base(message, inner, applicationCode, className, methodName)
        {
        }
    }

    public class ErrorResult
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }

    public class BadRequestErrorResult
    {
        [JsonProperty("Message")]
        public string Message { get; set; }
    }

    public class ModelStateErrorResult
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ModelState")]
        public Dictionary<String, String[]> ModelState { get; set; }
    }
}
