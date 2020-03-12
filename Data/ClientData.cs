using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetProject.Data;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;

namespace VetProject.Data
{
    public class ClientData : IRepository<Client>
    {
        public IEnumerable<Client> List()
        {
            IEnumerable<Client> clients = new VetDbContext().Clients.ToList();
            return clients;
        }
        public Client GetById(int id)
        {
            return new VetDbContext().Clients.Find(id);
        }
        public void Insert(Client cli)
        {
            var context = new VetDbContext();
            context.Clients.Add(cli);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var context = new VetDbContext();
            context.Clients.Remove(context.Clients.Find(id));
            context.SaveChanges();
        }
        public void Update(Client updated)
        {
            var context = new VetDbContext();
            var client = context.Clients.Find(updated.Id);
            if (client != null)
            {
                client.FullName = updated.FullName;
                client.Email = updated.Email;
                client.PhoneNumber = updated.PhoneNumber;
            }
            context.SaveChanges();
        }
    }
}