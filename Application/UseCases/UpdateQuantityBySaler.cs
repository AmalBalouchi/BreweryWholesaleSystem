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

        public UpdateQuantityBySaler(ISalerRepository salerRepository)
        {
            _salerRepository = salerRepository;
        }

        public async Task Execute(int salerId, int beerId, int newQuantity)
        {
            var saler = await _salerRepository.GetSalerByIdAsync(salerId);
            if (saler == null) throw new Exception("Saler does not exist");

            var salerStock = saler.salerStocks.FirstOrDefault(ss => ss.BeerId == beerId);
            if (salerStock == null) throw new Exception("Beer does not exist");

            salerStock.Quantity = newQuantity;

            await _salerRepository.UpdateSalerAsync(saler);

        }
    }
}
