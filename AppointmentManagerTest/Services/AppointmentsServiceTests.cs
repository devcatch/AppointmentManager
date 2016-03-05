using NUnit.Framework;
using Moq;
using AppointmentManager.Services.Rest;
using System.Threading;
using System.Collections.Generic;
using AppointmentManager;
using AppointmentManager.Services.Appointments;

namespace AppointmentManagerTest
{
	[TestFixture]
	public class AppointmentsServiceTests
	{
		Mock<IRestService> _restServiceMock;

		[SetUp]
		public void SetUp()
		{
			_restServiceMock = new Mock<IRestService>();	
		}

		[Test]
		public async void AppointmentServiceCallRestServiceDuringLoading ()
		{
			// Arrange
			var list = It.IsAny<List<Appointment>>();

			_restServiceMock.Setup(moq => moq.GetAsync<List<Appointment>>(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync (list);

			var appointmentsService = new AppointmentsService (_restServiceMock.Object);

			// Act
			var result = await appointmentsService.GetAppointments (It.IsAny<string>());

			// Assert
			_restServiceMock.Verify(moq => moq.GetAsync<List<Appointment>>(It.IsAny<string>(), It.IsAny<CancellationToken>()),
				Times.Once);
			
			Assert.IsTrue (result == list);
		}

		[Test]
		public async void AppointmentServiceMakeCorectUrl ()
		{
			// Arrange
			var list = It.IsAny<List<Appointment>>();

			var userId = "2331211";
			var rightUrl = $"http://service.appointments.com/users/{userId}/appointments";

			_restServiceMock.Setup(moq => moq.GetAsync<List<Appointment>>(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync (list);

			var appointmentsService = new AppointmentsService (_restServiceMock.Object);

			// Act
			var result = await appointmentsService.GetAppointments (userId);

			// Assert
			_restServiceMock.Verify(moq => moq.GetAsync<List<Appointment>>(rightUrl, It.IsAny<CancellationToken>()),
				Times.Once);

			Assert.IsTrue (result == list);
		}
	}
}

