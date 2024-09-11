using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AddSaleBySaler
    {
        private readonly ISalerRepository _salerRepository;
        private readonly IBeerRepository _beerRepository;

        public AddSaleBySaler(ISalerRepository salerRepository, IBeerRepository beerRepository)
        {
            _salerRepository = salerRepository;
            _beerRepository = beerRepository;
        }
        public async Task Execute(int salerId, int beerId, int quantity)
        {
            // Verify if the saler already exists in the saler table
            var saler = await _salerRepository.GetSalerByIdAsync(salerId);
            if (saler == null) throw new Exception("Saler does not exist");

            // Verify if the Beer already exists in the Beer table
            var beer = await _beerRepository.GetBeerByIdAsync(beerId);
            if (beer == null) throw new Exception("Beer does not exist");

            // To avoid record duplication Use the salerStock List of the saler to check that
            // the sale is not already exist in the salerStocks table
            var salerStock = saler.salerStocks.FirstOrDefault(ss => ss.BeerId == beerId && ss.SalerId == salerId);

            if (salerStock == null)
            {
                salerStock = new SalerStock
                {
                    BeerId = beerId,
                    Quantity = quantity,
                    SalerId = salerId
                };
                //Add the new sale to the salerStocks list
                saler.salerStocks.Add(salerStock);
            }
            else
            {
                throw new Exception("Sale for this Beer already exist for this Saler");
            }

            // Update the saler table according to the change in the salerStocks list
            await _salerRepository.UpdateSalerAsync(saler);
        }
    }
}