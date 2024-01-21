using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Travello.DataAccess.Repository;
using Travello.DataAccess.Repository.IRepository;
using Travello.Models;

namespace TravelloTestRepository
{
	public class RepositoryTests
	{
		private Repository<Travel> _travelRepository;
		private List<Travel> _travelData;

		[SetUp]
		public void Setup()
		{
			_travelData = new List<Travel>
			{
				new Travel { Id = 1, City = "Barcelona" },
				new Travel { Id = 2, City = "Split" },
				new Travel { Id = 3, City = "Zakopane" }
			};

			// Utworzenie repozytorium z danymi w pamięci
		}

		[Test]
		public void GetAll_ReturnsAllTravels()
		{
			// Act
			var result = _travelRepository.GetAll().ToList();

			// Assert
			Assert.AreEqual(_travelData.Count, result.Count);
			CollectionAssert.AreEquivalent(_travelData, result);
		}

		[Test]
		public void GetFirstOrDefault_ReturnsCorrectTravel()
		{
			// Act
			var result = _travelRepository.GetFirstOrDefault(t => t.City == "Barcelona");

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual("Barcelona", result.City);
		}

		[Test]
		public void Add_AddsNewTravel()
		{
			// Arrange
			var newTravel = new Travel { Id = 4, City = "Paris" };

			// Act
			_travelRepository.Add(newTravel);
			var result = _travelRepository.GetAll().ToList();

			// Assert
			Assert.AreEqual(_travelData.Count + 1, result.Count);
			Assert.IsTrue(result.Any(t => t.City == "Paris"));
		}

		[Test]
		public void Remove_RemovesTravel()
		{
			// Arrange
			var travelToRemove = _travelData.First(t => t.City == "Split");

			// Act
			_travelRepository.Remove(travelToRemove);
			var result = _travelRepository.GetAll().ToList();

			// Assert
			Assert.AreEqual(_travelData.Count - 1, result.Count);
			Assert.IsFalse(result.Any(t => t.City == "Split"));
		}

		// Dodaj więcej testów w miarę potrzeb

	
	}
}