using AppointmentManager.Services.Rest;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace AppointmentManager.Services.AppointmentsService
{
	/// <summary>
	/// Realisation of IAppointmentsService interface .
	/// </summary>
	public class AppointmentsService : IAppointmentsService
	{
		readonly IRestService _restService;

		public AppointmentsService(IRestService restService)
		{
			_restService = restService;
		}

		#region IAppointmentsService implementation

		/// <summary>
		/// Method for gets the appointments from server.
		/// </summary>
		/// <returns>The List of appointments.</returns>
		/// <param name="userId">User identifier.</param>
		public Task<List<Appointment>> GetAppointmentsAsync (string userId)
		{
			return _restService.GetAsync<List<Appointment>> (
				$"http://service.appointments.com/users/{userId}/appointments",
				CancellationToken.None
			);
		}

		#endregion

	}
}

