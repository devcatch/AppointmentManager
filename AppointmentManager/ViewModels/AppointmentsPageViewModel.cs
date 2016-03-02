using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using AppointmentManager.Services.Appointments;
using System;

namespace AppointmentManager
{
	public class AppointmentsPageViewModel : BaseViewModel
	{ 
		readonly IAppointmentsService _appointmentsService = DependencyService.Get<IAppointmentsService> ();

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

		public async Task DoReload ()
		{
			try{
				LabelText = "Upcoming Appointments";
				Appointments = await _appointmentsService.GetAppointments (Constants.UserId);	
			}
			catch(Exception e){
				LabelText = e.Message;
			}
		}

		async Task DoSelectedItem ()
		{
			System.Diagnostics.Debug.WriteLine("UPDATE");
		}
	}
}

