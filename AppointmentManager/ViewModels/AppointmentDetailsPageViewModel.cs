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

		public Appointment Appointment{
			get;
			private set;
		}

		public Doctor Doctor {
			get;
			private set;
		}

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
			Appointment = appointment;
		}

		/// <summary>
		/// Loads the doctor info.
		/// </summary>
		/// <returns>The doctor info.</returns>
		public async Task LoadDoctorInfo()
		{
			Doctor = await _doctorService.GetDoctorInfoAsync(Appointment.DoctorId);
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
			return _navigation.PushAsync(new DoctorDetailsPage(Doctor));
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
		public string DoctorName => Doctor?.Name;

		/// <summary>
		/// Gets the notes.
		/// </summary>
		/// <value>The notes.</value>
		public string Notes => Appointment?.Notes;

		/// <summary>
		/// Gets the time.
		/// </summary>
		/// <value>The time.</value>
		public string Time => (Appointment != null) ? Appointment.VisitDate + " " + Appointment.VisitTime : null;
	}
}

