using System;

namespace AppointmentManager
{
	/// <summary>
	/// Appointment class.
	/// </summary>
	public class Appointment
	{
		public string Id { get; set; }

		public int Time { get; set; }

		public string DoctorId { get; set; }

		public string Notes { get; set; }

		public string DoctorType { get; set; }

		public string VisitDate
		{
			get { return TimeAsDateTime(Time).ToString("dd.MM.yyyy"); }
		}

		public string VisitTime
		{
			get { return TimeAsDateTime(Time).ToString("t"); }
		}

		/// <summary>
		/// Method for convert unix timestamp to DateTime.
		/// </summary>
		/// <returns>DateTime object.</returns>
		/// <param name="unixTimestamp">Unix timestamp.</param>
		static DateTime TimeAsDateTime (int unixTimestamp)
		{
			// Unix timestamp is seconds past epoch
			var dtDateTime = new DateTime (1970, 1, 1, 0, 0, 0, 0);
			dtDateTime = dtDateTime.AddSeconds (unixTimestamp).ToLocalTime ();
			return dtDateTime;
		}
	}
}

