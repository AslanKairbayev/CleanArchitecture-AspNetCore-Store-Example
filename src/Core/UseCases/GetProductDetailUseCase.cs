using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public class GetProductDetailUseCase : IGetProductDetailUseCase
    {
        private readonly IProductRepository repository;

        public GetProductDetailUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(GetProductDetailRequest request, IOutputPort<GetProductDetailResponse> outputPort)
        {
            var product = await repository.GetProductById(request.Id);

            if (product != null)
            {
                outputPort.Handle(new GetProductDetailResponse(product.Id, product.Name, product.Description, product.Price, product.Category, true));

                return true;
            }

            outputPort.Handle(new GetProductDetailResponse(false, $"ProductId - {request.Id} was not found"));

            return false;
        }
    }
}
