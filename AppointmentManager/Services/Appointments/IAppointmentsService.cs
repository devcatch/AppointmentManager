using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentManager.Services.Appointments
{
	public interface IAppointmentsService
	{
		Task<List<Appointment>> GetAppointments(string userId);
	}
}

