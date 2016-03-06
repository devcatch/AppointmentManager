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

		/// <summary>
		/// Gets the open hours.
		/// </summary>
		/// <value>The open hours.</value>
		public string OpeningHours {
			get {
				return String.Join("\n", Doctor?.OpeningHours.ToArray());
			}
		}

		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		public string Address => Doctor?.Street + "\n" + Doctor?.PostalCode + " " + Doctor?.City;

		/// <summary>
		/// Gets the name of the doctor.
		/// </summary>
		/// <value>The name of the doctor.</value>
		public string DoctorName => Doctor?.Name;

		/// <summary>
		/// Gets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		public double? Latitude => Doctor?.Latitude;

		/// <summary>
		/// Gets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public double? Longitude => Doctor?.Longitude;
	}
}

