using System;
using AppointmentManager.Services.Rest;
using System.Threading.Tasks;
using System.Threading;

namespace AppointmentManager.Services.DoctorService
{
	public class DoctorService : IDoctorService
	{
		readonly IRestService _restService;

		public DoctorService (IRestService restService)
		{
			_restService = restService;
		}

		#region IDoctorService implementation

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

