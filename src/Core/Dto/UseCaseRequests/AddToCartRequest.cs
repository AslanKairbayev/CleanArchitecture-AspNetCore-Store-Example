using Core.Dto.UseCaseResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests
{
    public class AddToCartRequest : IRequest<AddToCartResponse>
    {
        public int ProductId { get; }

        public AddToCartRequest(int productId)
        {
            ProductId = productId;
        }
    }
}
