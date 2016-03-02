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

		Command _itemSelected;

		public Command ItemSelected {
			get {
				return _itemSelected ??
					(_itemSelected = new Command (async () => {
						Inactive = false;
						await DoSelectedItem ();
						Inactive = true;
					}, () => Inactive));
			}
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
			Appointments = new List<Appointment> ()
			{
				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "2",
					Notes = "Ear doctor",
					Time = 1456909260
				},

				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "3",
					Notes = "Ear doctor",
					Time = 1456924512 - random.Next(1000,6000)
				},

				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "5",
					Notes = "Audiologist",
					Time = 1456924512 - random.Next(1000,6000)
				},

				new Appointment(){
					Id = $"{random.Next()}",
					DoctorId = "7",
					Notes = "Audiologist",
					Time = 1456924512 - random.Next(1000,6000)
				},
			};
		}

		async Task DoSelectedItem ()
		{
			System.Diagnostics.Debug.WriteLine("UPDATE");
		}
	}
}

