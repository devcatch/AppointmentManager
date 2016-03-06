﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppointmentManager
{
	public partial class DoctorDetailsPage : ContentPage
	{
		public DoctorDetailsPage (Doctor doctor)
		{
			InitializeComponent ();
			BindingContext = new DoctorDetailsPageViewModel (doctor);
		}
	}
}

