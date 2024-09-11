using Application.Services;
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
    public class DeleteBeerByBrewerTest
    {
        [Fact]
        public async Task DeleteBeerByBrewer_Valid()
        {
            // Arrange
            var mockBeerRepository = new Mock<IBeerRepository>();
            var useCase = new DeleteBeerByBrewer(mockBeerRepository.Object);
            var beerId = 1;
            var brewerId = 2;

            // Act
            await useCase.ExecuteAsync(beerId, brewerId);

            // Assert
            mockBeerRepository.Verify(s => s.DeleteBeerByBrewer(beerId, brewerId), Times.Once);
        }

        [Fact]
        public async Task DeleteBeerByBrewer_InvalidBeerException()
        {
            // Arrange
            var mockBeerRepository = new Mock<IBeerRepository>();
            var beerId = 1;
            var brewerId = 2;

            // Setup the repository to throw an exception when trying to delete a non-existent beer
            mockBeerRepository.Setup(r => r.DeleteBeerByBrewer(beerId, brewerId))
                              .ThrowsAsync(new Exception("Beer does not exist"));

            var useCase = new DeleteBeerByBrewer(mockBeerRepository.Object);

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => useCase.ExecuteAsync(beerId, brewerId));

            // Assert
            Assert.Equal("Beer does not exist", exception.Message);

            // Verify that DeleteBeerByBrewer was called once
            mockBeerRepository.Verify(r => r.DeleteBeerByBrewer(beerId, brewerId), Times.Once);
        }
    }
}
