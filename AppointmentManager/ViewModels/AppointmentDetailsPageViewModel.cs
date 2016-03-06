using System.Threading.Tasks;
using AppointmentManager.Services.DoctorService;
using Xamarin.Forms;

namespace AppointmentManager
{
	/// <summary>
	/// View model for AppointmentDetailsPage .
	/// </summary>
	public class AppointmentDetailsPageViewModel : BaseViewModel
	{
		readonly IDoctorService _doctorService;
		readonly INavigation _navigation;

		// TODO : To propery
		readonly Appointment _appointment;

		// TODO : To propery
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
		/// Loads the doctor info.
		/// </summary>
		/// <returns>The doctor info.</returns>
		public async Task LoadDoctorInfo()
		{
			_doctor = await _doctorService.GetDoctorInfoAsync(_appointment.DoctorId);
			OnPropertyChanged ("DoctorName");
		}

		Command _doctorNameClick;
		/// <summary>
		/// Gets the click doctor name command.
		/// </summary>
		/// <value>The click doctor name command.</value>
		public Command ClickDoctorNameCommand {
			get {
				return _doctorNameClick ??
					(_doctorNameClick = new Command (async () => {
						Inactive = false;
						await OpenDoctorDetail ();
						Inactive = true;
					}, () => Inactive));
			}
		}

		/// <summary>
		/// Opens the doctor detail.
		/// </summary>
		/// <returns>The doctor detail.</returns>
		Task OpenDoctorDetail ()
		{
			return _navigation.PushAsync(new Page());
		}

		/// <summary>
		/// Changes the can execute. Should be overridden in inherited classes;
		/// </summary>
		public override void ChangeCanExecute ()
		{
			base.ChangeCanExecute ();
			ClickDoctorNameCommand.ChangeCanExecute ();
		}

		/// <summary>
		/// Gets the notes.
		/// </summary>
		/// <value>The notes.</value>
		public string DoctorName => _doctor?.Name;

		/// <summary>
		/// Gets the notes.
		/// </summary>
		/// <value>The notes.</value>
		public string Notes => _appointment?.Notes;

		/// <summary>
		/// Gets the time.
		/// </summary>
		/// <value>The time.</value>
		public string Time => (_appointment != null) ? _appointment.VisitDate + " " + _appointment.VisitTime : null;
	}
}

