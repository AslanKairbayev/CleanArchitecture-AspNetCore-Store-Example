using Core.Dto;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Web.Infrastructure;

namespace Web.Services
{
    public class SessionCartService : CartService, ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;        

        public SessionCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            session = _httpContextAccessor.HttpContext.Session;

            if (session.Keys.Contains("CartService"))
            {
                base.lineCollection = session.GetJson<List<CartLineDto>>("CartService");
            }
        }

        public override async Task AddItem(ProductDto product, int quantity)
        {            
            await base.AddItem(product, quantity);
            session.SetJson<List<CartLineDto>>("CartService", lineCollection);
        }

        public override async Task RemoveLine(ProductDto product)
        {
            await base.RemoveLine(product);
            session.SetJson<List<CartLineDto>>("CartService", lineCollection);
        }

        public override async Task Clear()
        {
            await base.Clear();
            session.Remove("CartService");
        }
    }
}
