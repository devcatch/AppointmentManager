using NUnit.Framework;
using Moq;
using AppointmentManager;

namespace AppointmentManagerTest
{
	[TestFixture]
	public class DoctorDetailsPageViewModelTests
	{
		[Test]
		public void ViewModelWasInitialisedCorrectly ()
		{
			// Arrange
			var doctor = new Mock<Doctor>().Object;

			// Act
			var vm = new DoctorDetailsPageViewModel(doctor);

			// Assert
			Assert.IsTrue(vm.Doctor == doctor);
		}

	}
}

