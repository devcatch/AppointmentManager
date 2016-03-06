using NUnit.Framework;
using Moq;
using AppointmentManager;
using AppointmentManager.Services.AppointmentsService;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppointmentManagerTests
{
	[TestFixture]
	public class AppointmentsPageViewModelTests
	{
		Mock<IAppointmentsService> _appointmentsServiceMock;
		Mock<INavigation> _navigationMock;

		[SetUp]
		public void SetUp()
		{
			_appointmentsServiceMock = new Mock<IAppointmentsService>();
			_navigationMock = new Mock<INavigation>();
			typeof(AppointmentDetailsPage).TypeInitializer.Invoke(null, null);
		}



		[Test]
		public void ViewModelWasInitialisedCorrectly ()
		{
			// Act
			var vm = new AppointmentsPageViewModel (_appointmentsServiceMock.Object, null);

			// Assert
			Assert.IsTrue (vm.ReloadCommand != null);
			Assert.IsTrue (vm.ItemSelectedCommand != null);
			Assert.IsTrue (vm.Appointments == null);
			Assert.IsTrue (vm.LabelText == "Upcoming Appointments");
		}

		[Test]
		public void ViewModelCallAppointmentsService ()
		{
			// Arrange
			var list = new Mock<List<Appointment>> ().Object;
			_appointmentsServiceMock.Setup (m => m.GetAppointmentsAsync (It.IsNotNull<string> ())).ReturnsAsync (list);
			var vm = new AppointmentsPageViewModel (_appointmentsServiceMock.Object, null);

			// Act
			vm.ReloadCommand.Execute(null);

			// Assert
			_appointmentsServiceMock.Verify(moq => moq.GetAppointmentsAsync(It.IsNotNull<string>()),
				Times.Once);

			Assert.IsTrue (vm.Appointments == list);
		}

		[Test]
		public void ViewModelPushPageAfteSelectItem ()
		{
			// Arrange
			var appointment =new Mock<Appointment>().SetupAllProperties().Object;
			_navigationMock.Setup (moq => moq.PushAsync (It.IsAny<Page>()));
			var vm = new AppointmentsPageViewModel (null, _navigationMock.Object);

			AppointmentDetailsPage.CreateAppointmentDetailsPage = (obj) =>
			{
				return (Page) new System.Object();
			};

			// Act
			vm.ItemSelectedCommand.Execute(appointment);

			// Assert
			_navigationMock.Verify(moq => moq.PushAsync(null), Times.Once);
			Assert.True(true);
		}

//		Xamarin.Forms.Page can't be created without platform
//		[Test]
//		public void ViewModelPushRightDetailsPage ()
//		{
//			// Arrange
//			var appointment =new Mock<Appointment>().SetupAllProperties().Object;
//			_navigationMock.Setup (moq => moq.PushAsync (It.IsNotNull<AppointmentDetailsPage>()));
//			var vm = new AppointmentsPageViewModel (null, _navigationMock.Object);
//
//			// Act
//			vm.ItemSelectedCommand.Execute(appointment);
//
//			// Assert
//			_navigationMock.Verify(moq => moq.PushAsync(It.IsNotNull<AppointmentDetailsPage>()), Times.Once);
//		}
	}
}

