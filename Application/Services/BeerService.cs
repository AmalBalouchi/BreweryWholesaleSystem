using Application.Services;
using Domain.Entities;
using Domain.Interfaces;

public class BeerService : IBeerService
{
        // This is a sample of validation to show the use of a service
         public Task ValidateBeerAsync(Beer beer)
        {
            if (beer.Alcohol <= 0)
                throw new ArgumentException("Alcohol content must be positive");

            return Task.CompletedTask;
        }

    }
