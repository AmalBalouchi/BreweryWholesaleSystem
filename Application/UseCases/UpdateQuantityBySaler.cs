using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UpdateQuantityBySaler
    {
        private readonly ISalerRepository _salerRepository;
        private readonly IBeerRepository _beerRepository;

        public UpdateQuantityBySaler(ISalerRepository salerRepository, IBeerRepository beerRepository)
        {
            _salerRepository = salerRepository;
            _beerRepository = beerRepository;
        }

        public async Task Execute(int salerId, int beerId, int newQuantity)
        {
            // Check that the salerId exists in the saler table
            var saler = await _salerRepository.GetSalerByIdAsync(salerId);
            if (saler == null) throw new Exception("Saler does not exist");

            // Check that the beerId exists in the Beer table
            var beer = await _beerRepository.GetBeerByIdAsync(beerId);
            if (beer == null) throw new Exception("Beer does not exist");

            // Using salerStocks list from the saler entity verify that the Beer bellongs to the Saler
            // by verifying that the beerId and salerId has already a record in the salerStocks entity
            var salerStock = saler.salerStocks.FirstOrDefault(ss => ss.BeerId == beerId && ss.SalerId == salerId);
            if (salerStock == null) throw new Exception("Beer does not bellong to this saler");

            salerStock.Quantity = newQuantity;

            // Update the saler table according to the change in the salerStocks list
            await _salerRepository.UpdateSalerAsync(saler);

        }
    }
}
