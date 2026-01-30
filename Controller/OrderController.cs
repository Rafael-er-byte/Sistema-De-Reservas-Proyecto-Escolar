using System;
using System.Collections.Generic;
using SistemaDeReservas.Model;
using SistemaDeReservas.Repository;

namespace SistemaDeReservas.Controller
{
    public class OrderController
    {
        private readonly OrderRepository repository;

        public OrderController(OrderRepository repo)
        {
            repository = repo;
        }

        public Order CreateNew(int idClient, Dictionary<Item, int> items)
        {
            Order order = Order.CreateNew(idClient, items);

            repository.Create(order);

            return order;
        }


        public void Update(Order order, int idClient)
        {
            repository.Update(order);
        }

        public void Delete(int orderId)
        {
            repository.Delete(orderId);
        }

        public void ChangeStatus(int orderId, string status)
        {
            repository.UpdateStatus(orderId, status);
        }

        public List<Order> GetByCriteria(
            int idClient,
            string status,
            string clientNameLikeOrId)
        {
            OrderCriteria criteria = new OrderCriteria
            {
                status = status,
                clientNameLikeOrId = clientNameLikeOrId
            };

            return repository.GetByCriteria(criteria);
        }
    }
}
