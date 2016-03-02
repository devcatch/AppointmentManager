using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppointmentManager
{
	public class AppointmentsPageViewModel : BaseViewModel
	{ 
		public AppointmentsPageViewModel ()
		{
		}

		List<Appointment> _appointments;
		public List<Appointment> Appointments {
			get { return _appointments; }
			set { SetProperty (ref _appointments, value); }
		}

		string _labelText;
		public string LabelText {
			get { return _labelText; }
			set { SetProperty (ref _labelText, value); }
		}

		Command _reloadCommand;

		public Command ReloadCommand {
			get {
				return _reloadCommand ??
					(_reloadCommand = new Command (async () => {
						Inactive = false;
						await DoReload ();
						Inactive = true;
					}, () => Inactive));
			}
		}

		System.Random random = new System.Random();

		public async Task DoReload ()
		{
			LabelText = "dasdadasdasADSdadsadsadas DSas as ";
			System.Diagnostics.Debug.WriteLine("UPDATE");

			Appointments = new List<Appointment> ()
			{
				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "2"
				},

				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "3"
				},

				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "5"
				},

				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "7"
				},
			};
		}
	}
}

