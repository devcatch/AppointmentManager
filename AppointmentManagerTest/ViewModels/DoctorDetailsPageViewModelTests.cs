using NUnit.Framework;
using Moq;
using AppointmentManager;
using System.Collections.Generic;

namespace AppointmentManagerTest
{
	[TestFixture]
	public class DoctorDetailsPageViewModelTests
	{
		[Test]
		public void ViewModelWasInitialisedCorrectly ()
		{
			// Arrange
			var doctor = new Mock<Doctor>().SetupAllProperties().Object;
			doctor.Name = "dasda";
			doctor.OpeningHours = new List<string>{
				"dsadad",
				"dasdada",
				"mlkadsm"
			};
			doctor.City = "some city";
			doctor.Street = "some street";
			doctor.PostalCode = "PostalCode";
			doctor.Latitude = 1233.123;
			doctor.Longitude = 653.1997;


			// Act
			var vm = new DoctorDetailsPageViewModel(doctor);

			// Assert
			Assert.IsTrue(vm.Doctor == doctor);
			Assert.IsTrue(vm.OpeningHours != null);
			Assert.IsTrue(vm.Address != null);
			Assert.IsTrue(vm.Latitude == doctor.Latitude);
			Assert.IsTrue(vm.Longitude == doctor.Longitude);
		}

	}
}

