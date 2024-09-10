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
            var saler = await _salerRepository.GetSalerByIdAsync(salerId);
            if (saler == null) throw new Exception("Saler does not exist");

            var beer = await _beerRepository.GetBeerByIdAsync(beerId);
            if (beer == null) throw new Exception("Beer does not exist");

            var salerStock = saler.salerStocks.FirstOrDefault(ss => ss.BeerId == beerId);

            if (salerStock == null)
            {
                salerStock = new SalerStock
                {
                    BeerId = beerId,
                    Quantity = quantity,
                    SalerId = salerId
                };
                saler.salerStocks.Add(salerStock);
            }
            else
            {
                salerStock.Quantity += quantity;
            }

            await _salerRepository.UpdateSalerAsync(saler);
        }
    }
}