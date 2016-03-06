using System;

namespace AppointmentManager
{
	public class DoctorDetailsPageViewModel
	{
		public Doctor Doctor {
			get;
			private set;
		}

		public DoctorDetailsPageViewModel (Doctor doctor)
		{
			Doctor = doctor;
		}
	}
}

