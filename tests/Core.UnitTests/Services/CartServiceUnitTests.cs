using Core.Dto;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Core.UnitTests.Services
{
    public class CartServiceUnitTests
    {
        [Fact]
        public async void Can_Add_New_Lines()
        {
            var p1 = new ProductDto(1, "P1", null, 0, null);
            var p2 = new ProductDto(2, "P2", null, 0, null);

            CartService target = new CartService();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);

            var lines = target.Lines;

            var results = lines.ToArray();

            Assert.Equal(2, results.Length);
            Assert.Equal(results[0].ProductDto, p1);
            Assert.Equal(results[1].ProductDto, p2);
        }

        [Fact]
        public async void Can_Add_Quantity_For_Existing_Lines()
        {
            var p1 = new ProductDto(1, "P1", null, 0, null);
            var p2 = new ProductDto(2, "P2", null, 0, null);

            CartService target = new CartService();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);
            await target.AddItem(p1, 10);

            var lines = target.Lines;

            var results = lines.OrderBy(c => c.ProductDto.Id).ToArray();

            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public async void Can_Remove_Line()
        {
            var p1 = new ProductDto(1, "P1", null, 0, null);
            var p2 = new ProductDto(2, "P2", null, 0, null);
            var p3 = new ProductDto(3, "P3", null, 0, null);

            CartService target = new CartService();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 3);
            await target.AddItem(p3, 5);
            await target.AddItem(p2, 1);

            await target.RemoveLine(p2);

            var lines = target.Lines;

            Assert.Empty(lines.Where(c => c.ProductDto == p2));
            Assert.Equal(2, lines.Count());
        }

        [Fact]
        public async void Calculate_Cart_Total()
        {
            var p1 = new ProductDto(1, "P1", null, 100M, null);
            var p2 = new ProductDto(2, "P2", null, 50M, null);

            CartService target = new CartService();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);
            await target.AddItem(p1, 3);

            decimal result = await target.ComputeTotalValue();

            Assert.Equal(450M, result);
        }

        [Fact]
        public async void Can_Clear_Contents()
        {
            var p1 = new ProductDto(1, "P1", null, 100M, null);
            var p2 = new ProductDto(2, "P2", null, 50M, null);

            CartService target = new CartService();

            await target.AddItem(p1, 1);
            await target.AddItem(p2, 1);

            await target.Clear();

            var lines = target.Lines;

            Assert.Empty(lines);
        }
    }
}
