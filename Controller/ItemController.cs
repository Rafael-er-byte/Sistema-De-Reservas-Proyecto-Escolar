using System.Collections.Generic;
using SistemaDeReservas.Model;
using SistemaDeReservas.Repository;

namespace SistemaDeReservas.Controller
{
    public class ItemController
    {
        private readonly ItemRepository repository;

        public ItemController(ItemRepository repo)
        {
            repository = repo;
        }

        public void Create(string name, string description, decimal price)
        {
            Item item = Item.CreateNew(name, description, price);
            repository.Create(item);
        }

        public void Update(int id, string name, string description, decimal price)
        {
            Item item = Item.CreateExisting(id, name, description, price);
            repository.Update(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<Item> Search(int? id, string name)
        {
            SearchItemCriteria criteria = new SearchItemCriteria();

            if (id.HasValue && id.Value > 0)
                criteria.id = id.Value;

            if (!string.IsNullOrWhiteSpace(name))
                criteria.name = name;

            return repository.GetByCriteria(criteria);
        }

        public List<Item> GetAll()
        {
            return repository.GetByCriteria(new SearchItemCriteria());
        }
    }
}
