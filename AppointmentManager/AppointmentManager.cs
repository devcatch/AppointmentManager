using System;

using Xamarin.Forms;

namespace AppointmentManager
{
	public class App : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentManager.App"/> class.
		/// </summary>
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage (new AppointmentsPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

