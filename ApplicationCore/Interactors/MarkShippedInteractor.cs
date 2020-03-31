using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UseCases
{
    public class MarkShippedInteractor : IMarkShippedUseCase
    {
        private IOrderRepository repository;

        public MarkShippedInteractor(IOrderRepository repo)
        {
            repository = repo;
        }

        public void Handle(int orderId)
        {
            Order order = repository.FindById(orderId);
            if (order != null)
            {
                order.Shipped = true;
                repository.Update(order);
            }
        }
    }
}
