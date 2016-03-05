using AppointmentManager.Services.Rest;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace AppointmentManager.Services.Appointments
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

		public Task<List<Appointment>> GetAppointments (string userId)
		{
			return _restService.GetAsync<List<Appointment>> (
				$"http://service.appointments.com/users/{userId}/appointments",
				CancellationToken.None
			);
		}

		#endregion

	}
}

