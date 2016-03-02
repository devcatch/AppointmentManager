using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppointmentManager
{
	public partial class AppointmentsPage : ContentPage
	{
		AppointmentsPageViewModel _viewModel;

		public AppointmentsPage ()
		{
			InitializeComponent ();
			_viewModel = new AppointmentsPageViewModel ();
			BindingContext = _viewModel;
		}

		protected override async void OnAppearing ()
		{
			base.OnAppearing ();
			await _viewModel.DoReload ();
		}
	}
}

