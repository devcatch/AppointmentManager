using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppointmentManager
{
	public partial class AppointmentDetailsPage : ContentPage
	{
		public readonly Appointment Appointment;

		public AppointmentDetailsPage (Appointment appointment)
		{
			InitializeComponent ();
			Appointment = appointment;
		}
	}
}

