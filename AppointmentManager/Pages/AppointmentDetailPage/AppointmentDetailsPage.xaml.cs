using System;
using System.Collections.Generic;

using Xamarin.Forms;
using AppointmentManager.Services.Rest;
using AppointmentManager.Services.DoctorService;

namespace AppointmentManager
{
	public partial class AppointmentDetailsPage : ContentPage
	{
		public readonly Appointment Appointment;

		AppointmentDetailsPageViewModel _viewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentManager.AppointmentDetailsPage"/> class.
		/// </summary>
		/// <param name="appointment">Appointment.</param>
		/// <remarks>
		/// Create new view model and set it to BindingContext. All UI in XAML
		/// </remarks>
		public AppointmentDetailsPage (Appointment appointment)
		{
			InitializeComponent ();
			BindingContext = CreateViewModel (appointment);
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
			await _viewModel.LoadDoctorInfo ();
		}

		/// <summary>
		/// Creates the view model.
		/// </summary>
		/// <returns>The view model.</returns>
		AppointmentDetailsPageViewModel CreateViewModel(Appointment appointment)
		{
			var rest = new RestService ();
			var doctorService = new DoctorService (rest);
			_viewModel = new AppointmentDetailsPageViewModel (doctorService, Navigation, appointment);
			return _viewModel;
		}
	}
}

