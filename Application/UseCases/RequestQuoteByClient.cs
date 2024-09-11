using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class RequestQuoteByClient
    {
        private readonly ISalerRepository _salerRepository;
        private readonly IBeerRepository _beerRepository;

        public RequestQuoteByClient(ISalerRepository salerRepository, IBeerRepository beerRepository)
        {
            _salerRepository = salerRepository;
            _beerRepository = beerRepository;
        }

        public async Task<QuoteResponse> Execute(QuoteRequest request)
        {
            if (request.order == null || !request.order.Any())
                throw new Exception("The order cannot be empty");

            // Check for duplicate BeerId in the order
            var duplicateBeerIds = request.order
                .GroupBy(o => o.BeerId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateBeerIds.Any())
            {
                string duplicateBeerIdsStr = string.Join(", ", duplicateBeerIds);
                throw new Exception($"The order contains duplicate beers: {duplicateBeerIdsStr}");
            }

            var saler = await _salerRepository.GetSalerWithStock(request.SalerId);
            if (saler == null)
                throw new Exception("The saler must exist");

            var response = new QuoteResponse();
            decimal totalPrice = 0;
            int totalQuantity = 0;

            foreach (var order in request.order)
            {
                var stockItem = saler.salerStocks.FirstOrDefault(s => s.BeerId == order.BeerId);
                if (stockItem == null)
                    throw new Exception($"This beer is not sold by the saler");

                if (order.Quantity > stockItem.Quantity)
                    throw new Exception($"The number of beers ordered cannot be greater than the saler's stock for {order.BeerId}");

                decimal price = _beerRepository.GetBeerPriceById(order.BeerId);
                totalPrice += price * order.Quantity;
                totalQuantity += order.Quantity;
            }

            // Apply discounts
            if (totalQuantity > 20)
                response.DiscountPercentage = 0.20m;
            else if (totalQuantity > 10)
                response.DiscountPercentage = 0.10m;
            else
                response.DiscountPercentage = 0;

            response.DiscountAmount = totalPrice * response.DiscountPercentage;
            response.TotalPriceBeforeDiscount = totalPrice;
            response.TotalPriceAfterDiscount = totalPrice - response.DiscountAmount;
            return response;
        }
    }
}
