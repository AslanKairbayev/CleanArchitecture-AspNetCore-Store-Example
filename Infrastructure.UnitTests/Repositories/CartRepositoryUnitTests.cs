using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Infrastructure.UnitTests.Repositories
{
    public class CartRepositoryUnitTests
    {
        [Fact]
        public async void Can_Add_New_Lines()
        {
            var p1 = new Product { Id = 1, Name = "P1" };
            var p2 = new Product { Id = 2, Name = "P2" };

            CartRepository target = new CartRepository();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);

            var lines = await target.Lines();

            var results = lines.ToArray();

            Assert.Equal(2, results.Length);
            Assert.Equal(results[0].Product, p1);
            Assert.Equal(results[1].Product, p2);
        }

        [Fact]
        public async void Can_Add_Quantity_For_Existing_Lines()
        {
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };

            CartRepository target = new CartRepository();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);
            await target.AddItem(p1, 10);

            var lines = await target.Lines();

            var results = lines.OrderBy(c => c.Product.Id).ToArray();

            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public async void Can_Remove_Line()
        {
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };
            Product p3 = new Product { Id = 3, Name = "P3" };

            CartRepository target = new CartRepository();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 3);
            await target.AddItem(p3, 5);
            await target.AddItem(p2, 1);

            await target.RemoveLine(p2);

            var lines = await target.Lines();

            Assert.Empty(lines.Where(c => c.Product == p2));
            Assert.Equal(2, lines.Count());
        }

        [Fact]
        public async void Calculate_Cart_Total()
        {
            Product p1 = new Product { Id = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { Id = 2, Name = "P2", Price = 50M };

            CartRepository target = new CartRepository();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);
            await target.AddItem(p1, 3);

            decimal result = await target.ComputeTotalValue();

            Assert.Equal(450M, result);
        }

        [Fact]
        public async void Can_Clear_Contents()
        {
            Product p1 = new Product { Id = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { Id = 2, Name = "P2", Price = 50M };

            CartRepository target = new CartRepository();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);

            await target.Clear();

            var lines = await target.Lines();

            Assert.Empty(lines);
        }
    }
}
