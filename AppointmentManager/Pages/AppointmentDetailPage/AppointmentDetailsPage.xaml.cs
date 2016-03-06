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

		public AppointmentDetailsPage (Appointment appointment)
		{
			InitializeComponent ();
			BindingContext = CreateViewModel (appointment);
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

