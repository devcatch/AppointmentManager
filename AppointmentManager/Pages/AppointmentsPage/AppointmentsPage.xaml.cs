using System;
using System.Collections.Generic;

using Xamarin.Forms;
using AppointmentManager.Services.Rest;
using AppointmentManager.Services.Appointments;

namespace AppointmentManager
{
	/// <summary>
	/// Appointments page. First page of application
	/// </summary>
	public partial class AppointmentsPage : ContentPage
	{
		AppointmentsPageViewModel _viewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentManager.AppointmentsPage"/> class.
		/// </summary>
		/// <remarks>
		/// Create new view model and set it to BindingContext. All UI in XAML
		/// </remarks>
		public AppointmentsPage ()
		{
			InitializeComponent ();
			BindingContext = CreateViewModel();
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		/// <remarks>
		/// Overrided for loading content. Constructor can't be used for async code
		/// </remarks>
		protected override async void OnAppearing ()
		{
			base.OnAppearing ();
			await _viewModel.DoReload ();
		}

		/// <summary>
		/// Creates the view model.
		/// </summary>
		/// <returns>The view model.</returns>
		AppointmentsPageViewModel CreateViewModel()
		{
			var rest = new RestService ();
			var appointmentService = new AppointmentsService (rest);

			_viewModel = new AppointmentsPageViewModel (appointmentService, Navigation);
			return _viewModel;
		}
	}
}

