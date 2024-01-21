using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Travello.DataAccess.Repository.IRepository;
using Travello.Models;
using Travello.Models.ViewModels;
using TravelloWeb.Controllers;

namespace TravelloTestRepository
{
	public class TravelControllerTests
	{
		private TravelController _travelController;
		private Mock<IMain> _mainMock;
		private Mock<IWebHostEnvironment> _hostEnvironmentMock;

		[SetUp]
		public void Setup()
		{
			_mainMock = new Mock<IMain>();
			_hostEnvironmentMock = new Mock<IWebHostEnvironment>();

			_travelController = new TravelController(_mainMock.Object, _hostEnvironmentMock.Object);
		}

		[Test]
		public void Index_ReturnsViewResult()
		{
			// Act
			var result = _travelController.Index();

			// Assert
			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Create_ReturnsViewResult()
		{
			// Act
			var result = _travelController.Create();

			// Assert
			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Upsert_WithNullId_ReturnsViewResult()
		{
			// Act
			var result = _travelController.Upsert(null);

			// Assert
			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Upsert_WithExistingId_ReturnsViewResult()
		{
			// Act
			var result = _travelController.Upsert(1);

			// Assert
			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void GetAll_ReturnsJsonResult()
		{
			// Act
			var result = _travelController.GetAll();

			// Assert
			Assert.IsInstanceOf<JsonResult>(result);
		}

		[Test]
		public void Delete_WithExistingId_ReturnsJsonResult()
		{
			// Arrange
			var id = 1;

			// Act
			var result = _travelController.Delete(id);

			// Assert
			Assert.IsInstanceOf<JsonResult>(result);
		}

		// Dodaj wiêcej testów w miarê potrzeb
	}
}