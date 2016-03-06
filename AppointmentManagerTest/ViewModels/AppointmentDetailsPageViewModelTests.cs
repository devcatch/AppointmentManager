using System;
using NUnit.Framework;
using Moq;
using AppointmentManager;
using Xamarin.Forms;
using AppointmentManager.Services.DoctorService;

namespace AppointmentManagerTest
{
	[TestFixture]
	public class AppointmentDetailsPageViewModelTests
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
			var appoint = Mock.Of<Appointment>( m =>
				m.Time == 12313123 &&
				m.Notes == "Some notes");

			// Act
			var vm = new AppointmentDetailsPageViewModel (_doctorInfoServiceMock.Object, _navigationMock.Object, appoint);

			// Assert
			Assert.IsTrue(vm.Time != null);
			Assert.IsTrue(vm.Notes == "Some notes");
		}
	}
}

