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

			switch (response.StatusCode) {
			case HttpStatusCode.OK:
				if (!ContentIsEmpty (content))
					return JsonConvert.DeserializeObject<T> (content);
				break;
			default:
				throw new Exception (Constants.UnexpectedServerExceptionMessage);
				break;
			}
			return default(T);
		}

		static bool ContentIsEmpty (string content)
		{
			return string.IsNullOrWhiteSpace (content) || content == "{}";
		}

		//			System.Random random = new System.Random();
		//			Appointments = new List<Appointment> ()
		//			{
		//				new Appointment(){
		//					Id = $"{random.Next()}",
		//					DoctorId = "2",
		//					Notes = "Ear doctor",
		//					Time = 1456909260
		//				},
		//
		//				new Appointment(){
		//					Id = $"{random.Next()}",
		//					DoctorId = "3",
		//					Notes = "Ear doctor",
		//					Time = 1456924512 - random.Next(1000,6000)
		//				},
		//
		//				new Appointment(){
		//					Id = $"{random.Next()}",
		//					DoctorId = "5",
		//					Notes = "Audiologist",
		//					Time = 1456924512 - random.Next(1000,6000)
		//				},
		//
		//				new Appointment(){
		//					Id = $"{random.Next()}",
		//					DoctorId = "7",
		//					Notes = "Audiologist",
		//					Time = 1456924512 - random.Next(1000,6000)
		//				},
		//			};
    }
}