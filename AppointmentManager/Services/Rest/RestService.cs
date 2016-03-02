using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppointmentManager.Services.Rest
{
    class RestService : IRestService
    {
        public async Task<object> GetAsync(IRestRequest request, CancellationToken cancellationToken)
        {
            using (var client = CreateHttpClient(request.DefaultHeaders))
            {
                using (
                    var response =
                        await
                            client.GetAsync(
                                await GetRequestUrl(request.Host, request.RelativeUrl, request.UrlParameters),
                                cancellationToken).ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Can't load data");

                    return JsonConvert.DeserializeObject(data, request.ReturnValueType);
                }
            }
        }

        HttpClient CreateHttpClient(Dictionary<string, string> headerParams)
        {
            var httpClient = new HttpClient();
            foreach (var headerParam in headerParams)
                httpClient.DefaultRequestHeaders.Add(headerParam.Key, headerParam.Value);

            return httpClient;
        }

        async Task<string> GetRequestUrl(string host, string relativeUrl, Dictionary<string, string> parameters)
        {
			var queryString = parameters != null ? await BuildParametersString(parameters) : string.Empty;
			return $"{host}{relativeUrl}{queryString}";
        }

        Task<string> BuildParametersString(Dictionary<string, string> parameters)
        {
            var content = new FormUrlEncodedContent(parameters);
            return content.ReadAsStringAsync();
        }
    }
}