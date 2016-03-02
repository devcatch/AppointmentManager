using AppointmentManager.Services.Rest;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

[assembly: Xamarin.Forms.Dependency (typeof(AppointmentManager.Services.Appointments.AppointmentsService))]

namespace AppointmentManager.Services.Appointments
{
	/// <summary>
	/// Realisation of IAppointmentsService interface .
	/// </summary>
	public class AppointmentsService : IAppointmentsService
	{
		readonly IRestService _restService = DependencyService.Get<IRestService> ();

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

