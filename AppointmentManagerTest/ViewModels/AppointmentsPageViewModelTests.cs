﻿using NUnit.Framework;
using Moq;
using AppointmentManager;
using AppointmentManager.Services.Appointments;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppointmentManagerTestsWithMock
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
		public async void ViewModelCallAppointmentsService ()
		{
			// Arrange
			var list = It.IsAny<List<Appointment>> ();

			_appointmentsServiceMock.Setup (m => m.GetAppointments (It.IsAny<string> ())).ReturnsAsync (list);
			var vm = new AppointmentsPageViewModel (_appointmentsServiceMock.Object, null);

			// Act
			await vm.DoReload ();

			// Assert
			_appointmentsServiceMock.Verify(moq => moq.GetAppointments(It.IsAny<string>()),
				Times.Once);

			Assert.IsTrue (vm.Appointments == list);
		}

		[Test]
		public void ViewModelPushPageAfteSelectItem ()
		{
			// Arrange
			_navigationMock.Setup(moq => moq.PushAsync(It.IsAny<Page>()));
			var vm = new AppointmentsPageViewModel (null, _navigationMock.Object);

			// Act
			vm.ItemSelectedCommand.Execute(It.IsAny<Appointment>());

			// Assert
			_navigationMock.Verify(moq => moq.PushAsync(It.IsAny<Page>()), Times.Once);
		}
	}
}

