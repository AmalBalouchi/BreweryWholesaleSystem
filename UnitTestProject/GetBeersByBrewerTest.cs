using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class GetBeersByBrewerTest
    {
        [Fact]
        public async Task AddBeerByBrewer_Valid()
        {
            // Arrange
            var mockBeerRepository = new Mock<IBeerRepository>();
            var useCase = new GetBeersByBrewer(mockBeerRepository.Object);
            var brewerId = 1;

            var expectedBeers = new List<Beer>
            {
                new Beer { Id = 1, Name = "Beer1", BrewerId = brewerId },
                new Beer { Id = 2, Name = "Beer2", BrewerId = brewerId }
            };

            // Setup the repository to return the expected beers
            mockBeerRepository.Setup(r => r.GetBeersByBrewer(brewerId)).ReturnsAsync(expectedBeers);

            // Act
            var result = await useCase.ExecuteAsync(brewerId);

            // Assert
            Assert.Equal(expectedBeers, result);
        }
    }
}
