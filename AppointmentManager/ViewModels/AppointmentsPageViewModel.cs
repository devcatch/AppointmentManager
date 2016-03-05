using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using AppointmentManager.Services.Appointments;
using System;

namespace AppointmentManager
{
	/// <summary>
	/// View model for AppointmentsPage.
	/// </summary>
	public class AppointmentsPageViewModel : BaseViewModel
	{
		/// <summary>
		/// The appointments service.
		/// </summary>
		readonly IAppointmentsService _appointmentsService;
		readonly INavigation _navigation;

		public AppointmentsPageViewModel (IAppointmentsService appointmentsService, INavigation navigation)
		{
			_navigation = navigation;
			_appointmentsService = appointmentsService;
			_labelText = "Upcoming Appointments";
		}

		List<Appointment> _appointments;
		/// <summary>
		/// The appointments property for binding.
		/// </summary>
		/// <value>The appointments.</value>
		public List<Appointment> Appointments {
			get { return _appointments; }
			set { SetProperty (ref _appointments, value); }
		}

		string _labelText;
		/// <summary>
		/// The text property for binding
		/// </summary>
		/// <value>The label text.</value>
		public string LabelText {
			get { return _labelText; }
			set { SetProperty (ref _labelText, value); }
		}

		Command _itemSelectedCommand;

		/// <summary>
		/// The command for binding to the item select callback.
		/// </summary>
		/// <value>The item selected.</value>
		public Command ItemSelectedCommand {
			get {
				return _itemSelectedCommand ??
					(_itemSelectedCommand = new Command (async () => {
						Inactive = false;
						await DoSelectedItem ();
						Inactive = true;
					}, () => Inactive));
			}
		}

		Command _reloadCommand;

		/// <summary>
		/// The command for binding to the reload data callback.
		/// </summary>
		/// <value>The reload command.</value>
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

		/// <summary>
		/// Async method for reload content.
		/// </summary>
		/// <returns>Task</returns>
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

		/// <summary>
		/// Asycn method for show detail page.
		/// </summary>
		/// <returns>Task</returns>
		async Task DoSelectedItem ()
		{
			await _navigation.PushAsync (new Page ());
		}

		/// <summary>
		/// Changes the can execute. Should be overridden in inherited classes;
		/// </summary>
		public override void ChangeCanExecute ()
		{
			base.ChangeCanExecute ();
			ReloadCommand.ChangeCanExecute ();
			ItemSelectedCommand.ChangeCanExecute ();
		}
	}
}

