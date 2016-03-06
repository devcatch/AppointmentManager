using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppointmentManager
{
	public partial class DoctorDetailsPage : ContentPage
	{
		public DoctorDetailsPage (Doctor doctor)
		{
			InitializeComponent ();
			BindingContext = new DoctorDetailsPageViewModel (doctor);


			// Xamarin maps don't support binding. We should add all element from here.
			var position = new Position (doctor.Latitude, doctor.Longitude);
			map.MoveToRegion(new MapSpan (position, 0.05, 0.05));

			var pin = new Pin {
				Type = PinType.Place,
				Position = position,
				Label = "Doctor",
				Address = $"{doctor.Street} {doctor.PostalCode}"
			};
			map.Pins.Add(pin);
		}
	}
}

