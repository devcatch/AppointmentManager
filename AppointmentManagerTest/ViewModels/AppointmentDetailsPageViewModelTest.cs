using System;
using NUnit.Framework;
using Moq;
using AppointmentManager;
using Xamarin.Forms;

namespace AppointmentManagerTest
{
	[TestFixture]
	public class AppointmentDetailsPageViewModelTest
	{
		Mock<IDoctorService> _doctorInfoServiceMock;
		Mock<INavigation> _navigationMock;

		[SetUp]
		public void SetUp()
		{
			_doctorInfoServiceMock = new Mock<IDoctorService>();
			_navigationMock = new Mock<INavigation>();
		}

		[Test]
		public void ViewModelWasInitialisedCorrectly ()
		{
			// Arrange

			// Act
			var vm = new AppointmentDetailsPageViewModel (_doctorInfoServiceMock.Object, _navigationMock.Object, It.IsNotNull<Appointment>());

			// Assert
			Assert.IsTrue(vm.Time != null);
			Assert.IsTrue(vm.Notes != null);
		}


	}
}

