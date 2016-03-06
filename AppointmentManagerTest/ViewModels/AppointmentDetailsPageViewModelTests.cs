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
			var appointment = Mock.Of<Appointment>( m =>
				m.Time == 12313123 &&
				m.Notes == "Some notes");

			// Act
			var vm = new AppointmentDetailsPageViewModel (_doctorInfoServiceMock.Object, _navigationMock.Object, appointment);

			// Assert
			Assert.IsTrue(vm.Time != null);
			Assert.IsTrue(vm.Notes == "Some notes");
		}

		[Test]
		public async void ViewModelCallDoctorServiceForLoading ()
		{
			// Arrange
			var doctorId = "dsda11";
			var doctorInfo = Mock.Of<Doctor>();
			_doctorInfoServiceMock.Setup (moq => moq.GetDoctorInfoAsync(It.IsAny<string>())).ReturnsAsync(doctorInfo);
			var appointment = Mock.Of<Appointment> (m =>
				m.DoctorId == doctorId);

			var vm = new AppointmentDetailsPageViewModel (_doctorInfoServiceMock.Object, null, appointment);

			// Act
			await vm.LoadDoctorInfo();

			// Assert
			_doctorInfoServiceMock.Verify(moq => moq.GetDoctorInfoAsync(doctorId), Times.Once);
		}
	}
}

