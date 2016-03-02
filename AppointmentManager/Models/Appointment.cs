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

		public System.Collections.Generic.List<string> Notes { get; set; }
	}
}

