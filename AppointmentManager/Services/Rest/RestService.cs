using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

[assembly: Xamarin.Forms.Dependency (typeof(AppointmentManager.Services.Rest.RestService))]

namespace AppointmentManager.Services.Rest
{
	/// <summary>
	/// Rest service. Realisation of IRestService interface.
	/// </summary>
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

		/// <summary>
		/// Processes the response.
		/// </summary>
		/// <returns>Task.</returns>
		/// <param name="response">Response of HttpClient.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <typeparam name="T">The type of return value.</typeparam>
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

		/// <summary>
		/// Contents the is empty.
		/// </summary>
		/// <returns><c>true</c>, if is empty was contented, <c>false</c> otherwise.</returns>
		/// <param name="content">Content.</param>
		static bool ContentIsEmpty (string content)
		{
			return string.IsNullOrWhiteSpace (content) || content == "{}";
		}
    }
}