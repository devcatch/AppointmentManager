using System;

namespace AppointmentManager
{
	public class Appointment
	{
		public Appointment ()
		{
		}

		public string Id { get; set; }

		public int Time { get; set; }

		public string DoctorId { get; set; }

		public string Notes { get; set; }

		public string VisitDate
		{
			get { return TimeAsDateTime().ToString("dd.MM.yyyy"); }
		}

		public string VisitTime
		{
			get { return TimeAsDateTime().ToString("t"); }
		}

		public DateTime TimeAsDateTime ()
		{
			// Unix timestamp is seconds past epoch
			var dtDateTime = new DateTime (1970, 1, 1, 0, 0, 0, 0);
			dtDateTime = dtDateTime.AddSeconds (Time).ToLocalTime ();
			return dtDateTime;
		}
	}
}

