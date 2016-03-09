using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppointmentManager
{
	public partial class DoctorDetailsPage : ContentPage
	{
		public Doctor Doctor {
			get;
			private set;
		}

		public DoctorDetailsPage (Doctor doctor)
		{
			InitializeComponent ();
			Doctor = doctor;
			BindingContext = new DoctorDetailsPageViewModel (doctor);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
//			Xamarin maps don't support binding. We should add all element from here.
			var position = new Position (Doctor.Latitude, Doctor.Longitude);
			map.MoveToRegion(new MapSpan (position, 0.05, 0.05));

			var pin = new Pin {
				Type = PinType.Place,
				Position = position,
				Label = "Doctor",
				Address = $"{Doctor.Street} {Doctor.PostalCode}"
			};
			map.Pins.Add(pin);
		}
	}
}

