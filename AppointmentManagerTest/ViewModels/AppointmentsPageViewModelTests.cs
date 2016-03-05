﻿using NUnit.Framework;
using Moq;
using AppointmentManager;
using AppointmentManager.Services.Appointments;
using System.Collections.Generic;

namespace AppointmentManagerTestsWithMock
{
	[TestFixture]
	public class AppointmentsPageViewModelTests
	{
		Mock<IAppointmentsService> _appointmentsServiceMock;

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
			Assert.IsFalse (vm.ReloadCommand == null);
			Assert.IsFalse (vm.ItemSelectedCommand == null);
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
			await vm.DoReload ();

			// Act
			_appointmentsServiceMock.Verify(moq => moq.GetAppointments(It.IsAny<string>()),
				Times.Once);

			// Assert
			Assert.IsTrue (vm.Appointments == list);
		}
	}
}

