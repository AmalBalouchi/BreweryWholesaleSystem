using Domain.Entities;

namespace Application.UseCases
{
    public interface IRequestQuoteByClient
    {
        Task<QuoteResponse> Handle(QuoteRequest request);
    }
}
