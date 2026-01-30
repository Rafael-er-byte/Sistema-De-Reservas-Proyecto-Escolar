using System.Collections.Generic;
using SistemaDeReservas.Model;
using SistemaDeReservas.Repository;

namespace SistemaDeReservas.Controller
{
    public class ClientController
    {
        private readonly ClientRepository repository;

        public ClientController(ClientRepository repo)
        {
            repository = repo;
        }

        public void Create(string name, string tel, string mail)
        {
            Client client = Client.CreateNew(name, tel, mail);
            repository.Create(client);
        }

        public void Update(int id, string name, string tel, string mail)
        {
            Client client = Client.CreateExisting(id, name, tel, mail);
            repository.Update(client);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<Client> Search(int? id, string nameLike)
        {
            if (id == 0 && nameLike == null)
            {
                return repository.getByCriteria(null);
            }

            SearchClientCriteria criteria = BuildCriteria(id, nameLike);
            return repository.getByCriteria(criteria);
        }

        public List<Client> GetAll()
        {
            return repository.getByCriteria(null);
        }

        private SearchClientCriteria BuildCriteria(int? id, string nameLike)
        {
            SearchClientCriteria criteria = new SearchClientCriteria();

            if (id.HasValue && id.Value > 0)
                criteria.id = id.Value;

            if (!string.IsNullOrWhiteSpace(nameLike))
                criteria.nameLike = nameLike;

            return criteria;
        }
    }
}
