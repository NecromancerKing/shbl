﻿using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.UI.WebApi
{
    public class HttpClientUtility
    {
        #region Post

        #region Sync

        public static TResponseModel Post<TResponseModel>(string path, object model = null, string token = null)
        {
            try
            {
                return Post<TResponseModel, ModelStateErrorResult>(path, model, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Post<TResponseModel>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return Post<TResponseModel, ModelStateErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Post<TResponseModel, TErrorResult>(string path, object model = null, string token = null)
        {
            try
            {
                StringContent content = GetContent(model);
                return Post<TResponseModel, TErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Post<TResponseModel, TErrorResult>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return Send<TResponseModel, TErrorResult>(path, content, token, HttpMethod.Post);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ASync

        public static async Task<TResponseModel> PostAsync<TResponseModel>(string path, object model = null, string token = null)
        {
            try
            {
                return await PostAsync<TResponseModel, ModelStateErrorResult>(path, model, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> PostAsync<TResponseModel>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return await PostAsync<TResponseModel, ModelStateErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> PostAsync<TResponseModel, TErrorResult>(string path, object model = null, string token = null)
        {
            try
            {
                StringContent content = GetContent(model);
                return await PostAsync<TResponseModel, TErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> PostAsync<TResponseModel, TErrorResult>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return await SendAsync<TResponseModel, TErrorResult>(path, content, token, HttpMethod.Post);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion

        #region Get

        #region Sync

        public static TResponseModel Get<TResponseModel>(string path, string token = null)
        {
            try
            {
                return Get<TResponseModel, ModelStateErrorResult>(path, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Get<TResponseModel, TErrorResult>(string path, string token = null)
        {
            try
            {
                return Send<TResponseModel, TErrorResult>(path, null, token, HttpMethod.Get);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ASync

        public static async Task<TResponseModel> GetAsync<TResponseModel>(string path, string token = null)
        {
            try
            {
                return await GetAsync<TResponseModel, ModelStateErrorResult>(path, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> GetAsync<TResponseModel, TErrorResult>(string path, string token = null)
        {
            try
            {
                return await SendAsync<TResponseModel, TErrorResult>(path, null, token, HttpMethod.Get);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion

        #region Delete

        #region Sync

        public static TResponseModel Delete<TResponseModel>(string path, object model = null, string token = null)
        {
            try
            {
                return Delete<TResponseModel, ModelStateErrorResult>(path, model, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Delete<TResponseModel>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return Delete<TResponseModel, ModelStateErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Delete<TResponseModel, TErrorResult>(string path, object model = null, string token = null)
        {
            try
            {
                StringContent content = GetContent(model);
                return Delete<TResponseModel, TErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TResponseModel Delete<TResponseModel, TErrorResult>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return Send<TResponseModel, TErrorResult>(path, content, token, HttpMethod.Delete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ASync

        public static async Task<TResponseModel> DeleteAsync<TResponseModel>(string path, object model = null, string token = null)
        {
            try
            {
                return await DeleteAsync<TResponseModel, ModelStateErrorResult>(path, model, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> DeleteAsync<TResponseModel>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return await DeleteAsync<TResponseModel, ModelStateErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> DeleteAsync<TResponseModel, TErrorResult>(string path, object model = null, string token = null)
        {
            try
            {
                StringContent content = GetContent(model);
                return await DeleteAsync<TResponseModel, TErrorResult>(path, content, token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TResponseModel> DeleteAsync<TResponseModel, TErrorResult>(string path, HttpContent content = null, string token = null)
        {
            try
            {
                return await SendAsync<TResponseModel, TErrorResult>(path, content, token, HttpMethod.Delete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion

        #region Helpers

        private static StringContent GetContent(object model)
        {
            try
            {
                StringContent content = null;

                if (model != null)
                {
                    content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                }

                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static TResponseModel Send<TResponseModel, TErrorResult>(string path, HttpContent content, string token, HttpMethod method)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(method, new Uri(path));

                    if (content != null)
                    {
                        request.Content = content;
                    }

                    if (!String.IsNullOrEmpty(token))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    var result = client.SendAsync(request).Result;
                    String json = result.Content.ReadAsStringAsync().Result;

                    json = FixJson(json);

                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<TResponseModel>(json);
                    }
                    else
                    {
                        if (result.StatusCode != HttpStatusCode.Unauthorized)
                        {
                            throw new ApiException<TErrorResult>("Unable to perform Http action.", json);
                        }
                        else
                        {
                            throw new UnauthorizedApiException();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static async Task<TResponseModel> SendAsync<TResponseModel, TErrorResult>(string path, HttpContent content, string token, HttpMethod method)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(method, new Uri(path));

                    if (content != null)
                    {
                        request.Content = content;
                    }

                    if (!String.IsNullOrEmpty(token))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    var result = await client.SendAsync(request);
                    String json = await result.Content.ReadAsStringAsync();

                    json = FixJson(json);

                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<TResponseModel>(json);
                    }
                    else
                    {
                        if (result.StatusCode != HttpStatusCode.Unauthorized)
                        {
                            throw new ApiException<TErrorResult>("Unable to perform Http action.", json);
                        }
                        else
                        {
                            throw new UnauthorizedApiException();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string FixJson(string json)
        {
            return json.Replace("\"[", "[").Replace("]\"", "]").Replace("\\", "");
        }

        #endregion
    }
}
