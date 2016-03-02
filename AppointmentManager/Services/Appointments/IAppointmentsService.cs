using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentManager.Services.Appointments
{
	public interface IAppointmentsService
	{
		/// <summary>
		/// Method for gets the appointments from server.
		/// </summary>
		/// <returns>The List of appointments.</returns>
		/// <param name="userId">User identifier.</param>
		Task<List<Appointment>> GetAppointments(string userId);
	}
}

