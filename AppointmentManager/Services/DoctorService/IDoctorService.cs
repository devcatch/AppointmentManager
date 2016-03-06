using System;
using System.Threading.Tasks;

namespace AppointmentManager.Services.DoctorService
{
	public interface IDoctorService
	{
		/// <summary>
		/// Gets the appointments.
		/// </summary>
		/// <returns>The appointments.</returns>
		/// <param name="userId">User identifier.</param>
		Task<Doctor> GetDoctorInfoAsync(string doctorId);
	}
}

