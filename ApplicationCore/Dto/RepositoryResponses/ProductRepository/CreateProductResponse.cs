using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.ProductRepository
{
    public class CreateProductResponse : BaseRepositoryResponse
    {
        public int Id { get; set; }
        public CreateProductResponse(int id, bool success = false) : base(success)
        {
            Id = id;
        }
    }
}
