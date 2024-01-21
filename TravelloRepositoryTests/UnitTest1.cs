
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello.Models;

namespace Travello.Tests.Models
{
	[TestFixture]
	public class TravelTests
	{
		[Test]
		public void Name_Required()
		{
			// Arrange
			var travel = new Travel();

			// Act
			var result = ValidateModel(travel);

			// Assert
			Assert.AreEqual("The Name field is required.", result.ErrorMessage);
			Assert.AreEqual("Name", result.MemberNames.First());
		}

		[Test]
		public void Country_Required()
		{
			// Arrange
			var travel = new Travel { Name = "GH", Country = "", City = "ASF", TravelTime = DateTime.Now, GuideId = 1, Price = 500, Description = "Description" };

			// Act
			var result = ValidateModel(travel);
			var errorMessage = result.ErrorMessage ?? "";

			// Assert
			Assert.AreEqual("The Country field is required.", errorMessage);
		}


		[Test]
		public void City_IsRequired()
		{
			// Arrange
			var travel = new Travel { Name = "GH", Country = "Country", City = "", TravelTime = DateTime.Now, GuideId = 1, Price = 500, Description = "Description" };

			// Act
			var result = ValidateModel(travel);
			var errorMessage = result.ErrorMessage ?? "";

			// Assert
			Assert.AreEqual("The City field is required.", errorMessage);
		}



		

		[Test]
		public void Price_IsBetween10And1000()
		{
			// Arrange
			var travel = new Travel { Price = 500 };

			// Act
			var isValid = travel.Price >= 10 && travel.Price <= 1000;

			// Assert
			Assert.IsTrue(isValid);
		}

		[Test]
		public void Description_Required()
		{
			// Arrange
			var travel = new Travel { Name = "GH", Country = "Country", City = "cc", TravelTime = DateTime.Now, GuideId = 1, Price = 500, Description = "" };

			// Act
			var result = ValidateModel(travel);
			var errorMessage = result.ErrorMessage ?? "";

			// Assert
			Assert.AreEqual("The Description field is required.", errorMessage);
		}

		private ValidationResult ValidateModel(Travel travel)
		{
			var validationContext = new ValidationContext(travel);
			var validationResults = new List<ValidationResult>();
			Validator.TryValidateObject(travel, validationContext, validationResults, true);
			return validationResults.First();
		}
	}

}