 using System;
using AppointmentManager.Services.Rest;
using System.Threading.Tasks;
using System.Threading;

namespace AppointmentManager.Services.DoctorService
{
	/// <summary>
	/// Realisation of IDoctorService interface .
	/// </summary>
	public class DoctorService : IDoctorService
	{
		readonly IRestService _restService;

		public DoctorService (IRestService restService)
		{
			_restService = restService;
		}

		#region IDoctorService implementation

		/// <summary>
		/// Gets the appointments.
		/// </summary>
		/// <returns>The appointments.</returns>
		/// <param name="userId">User identifier.</param>
		/// <param name="doctorId">Doctor identifier.</param>
		public Task<Doctor> GetDoctorInfoAsync (string doctorId)
		{
			return _restService.GetAsync<Doctor> (
				$"http://service.appointments.com/doctors/{doctorId}",
				CancellationToken.None
			);
		}

		#endregion
	}
}

