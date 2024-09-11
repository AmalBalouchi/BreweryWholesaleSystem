using Moq;
using Xunit;
using Application.UseCases;
using Domain.Interfaces;
using Domain.Entities;
using Application.Services;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class AddBeerByBrewerTests
{
    [Fact]
    public async Task AddBeerByBrewer_Valid()
    {
        // Arrange
        var mockBeerRepository = new Mock<IBeerRepository>();
        var mockBeerService = new Mock<IBeerService>();

        var newBeer = new Beer { Id = 1002, Name = "Beer sample", Price = 3.01M };

        var useCase = new AddBeerByBrewer(mockBeerRepository.Object, mockBeerService.Object);

        // Act
        await useCase.ExecuteAsync(1, newBeer);

        // Assert
        mockBeerService.Verify(s => s.ValidateBeerAsync(newBeer), Times.Once);
        mockBeerRepository.Verify(r => r.AddBeerByBrewer(1, newBeer), Times.Once);
    }

    [Fact]
    public async Task AddBeerByBrewer_BrewerNotFoundException()
    {
        // Arrange
        var mockBeerRepository = new Mock<IBeerRepository>();
        var mockBeerService = new Mock<IBeerService>();

        var newBeer = new Beer { Id = 1003, Name = "Beer sample", Price = 1.99M };

        mockBeerRepository
            .Setup(r => r.AddBeerByBrewer(It.IsAny<int>(), It.IsAny<Beer>()))
            .ThrowsAsync(new KeyNotFoundException("Brewer not found"));

        // Act
        var useCase = new AddBeerByBrewer(mockBeerRepository.Object, mockBeerService.Object);

        // Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => useCase.ExecuteAsync(1, newBeer));
    }

}
