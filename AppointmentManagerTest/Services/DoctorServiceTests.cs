using System;
using NUnit.Framework;
using AppointmentManager.Services.Rest;
using Moq;
using AppointmentManager;
using System.Threading;
using AppointmentManager.Services.DoctorService;

namespace AppointmentManagerTest
{
	[TestFixture]
	public class DoctorServiceTests
	{
		Mock<IRestService> _restServiceMock;

		[SetUp]
		public void SetUp()
		{
			_restServiceMock = new Mock<IRestService>();	
		}

		[Test]
		public async void DoctorServiceCallRestServiceDuringLoading ()
		{
			// Arrange
			var doctorInfo = It.IsAny<Doctor>();

			_restServiceMock.Setup(moq => moq.GetAsync<Doctor>(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync (doctorInfo);

			var appointmentsService = new DoctorService (_restServiceMock.Object);

			// Act
			var result = await appointmentsService.GetDoctorInfoAsync (It.IsAny<string>());

			// Assert
			_restServiceMock.Verify(moq => moq.GetAsync<Doctor>(It.IsAny<string>(), It.IsAny<CancellationToken>()),
				Times.Once);

			Assert.IsTrue (result == doctorInfo);
		}

		[Test]
		public async void DoctorServiceMakeCorectUrl ()
		{
			// Arrange
			var doctorInfo = It.IsAny<Doctor>();
			var doctorId = "2331211";
			var rightUrl = $"http://service.appointments.com/doctors/{doctorId}";
			_restServiceMock.Setup(moq => moq.GetAsync<Doctor>(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync (doctorInfo);
			var appointmentsService = new DoctorService (_restServiceMock.Object);

			// Act
			var result = await appointmentsService.GetDoctorInfoAsync (doctorId);

			// Assert
			_restServiceMock.Verify(moq => moq.GetAsync<Doctor>(rightUrl, It.IsAny<CancellationToken>()),
				Times.Once);
			Assert.IsTrue (result == doctorInfo);
		}
	}
}

