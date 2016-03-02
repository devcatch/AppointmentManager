using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
			_viewModel = new AppointmentsPageViewModel ();
			BindingContext = _viewModel;
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
	}
}

