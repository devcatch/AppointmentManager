using System;

namespace AppointmentManager.Services.DoctorService
{
	public class DoctorService : IDoctorService
	{
		public DoctorService ()
		{
		}

		#region IDoctorService implementation

		public System.Threading.Tasks.Task<Doctor> GetDoctorInfoAsync (string doctorId)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

