using System;

namespace AppointmentManager
{
	public class Doctor
	{
		public Doctor ()
		{
		}

		public string Id { get; set; }

		public string Name { get; set; }

		public System.Collections.Generic.List<string> OpeningHours { get; set; }

		public string Street { get; set; }

		public string PostalCode { get; set; }

		public string City { get; set; }
	}
}

