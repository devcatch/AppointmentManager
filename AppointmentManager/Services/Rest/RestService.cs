using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

[assembly: Xamarin.Forms.Dependency (typeof(AppointmentManager.Services.Rest.RestService))]

namespace AppointmentManager.Services.Rest
{
	class RestService : IRestService
    {
		#region IRestService implementation

		public async Task<T> GetAsync<T> (string requestUrl, CancellationToken cancellationToken)
		{
			using (var httpClient = new HttpClient()) {
				var response = await httpClient.GetAsync (requestUrl, cancellationToken);
				return await ProcessResponse<T> (response, cancellationToken);
			}
		}

		#endregion

		async Task<T> ProcessResponse<T> (HttpResponseMessage response, CancellationToken cancellationToken)
		{
			var content = await response.Content.ReadAsStringAsync ();

			cancellationToken.ThrowIfCancellationRequested ();

			if (Constants.IsStubData && response.RequestMessage.RequestUri.AbsolutePath.Contains("/appointments")) {
				content = Constants.Appointments;
				response.StatusCode = HttpStatusCode.OK;
			}

			switch (response.StatusCode) {
			case HttpStatusCode.OK:
				if (!ContentIsEmpty (content))
					return JsonConvert.DeserializeObject<T> (content);
				break;
			default:
				throw new Exception (Constants.UnexpectedServerExceptionMessage);
			}
			return default(T);
		}

		static bool ContentIsEmpty (string content)
		{
			return string.IsNullOrWhiteSpace (content) || content == "{}";
		}
    }
}