using System;
using AppointmentManager.Services.DoctorService;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppointmentManager
{
	/// <summary>
	/// View model for AppointmentDetailsPage .
	/// </summary>
	public class AppointmentDetailsPageViewModel : BaseViewModel
	{
		readonly IDoctorService _doctorService;
		readonly INavigation _navigation;
		readonly Appointment _appointment;

		Doctor _doctor;

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentManager.AppointmentDetailsPageViewModel"/> class.
		/// </summary>
		/// <param name="doctorService">Doctor service.</param>
		/// <param name="navigation">Navigation.</param>
		/// <param name="appointment">Appointment.</param>
		public AppointmentDetailsPageViewModel (IDoctorService doctorService, INavigation navigation, Appointment appointment)
		{
			_doctorService = doctorService;
			_navigation = navigation;
			_appointment = appointment;
		}

		/// <summary>
		/// Gets the time.
		/// </summary>
		/// <value>The time.</value>
		public string Time => (_appointment != null) ? _appointment.VisitDate + " " + _appointment.VisitTime : null;

		/// <summary>
		/// Gets the notes.
		/// </summary>
		/// <value>The notes.</value>
		public string Notes => _appointment?.Notes;

		public async Task LoadDoctorInfo()
		{
			_doctor = await _doctorService.GetDoctorInfoAsync(_appointment.DoctorId);
		}
	}
}

