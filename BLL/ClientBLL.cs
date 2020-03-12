using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetProject.Data;
using VetManagement.Core.Interfaces;
using VetManagement.Core.Model;

namespace BLL
{
    public class ClientBLL : IRepository<Client>
    {
        public void Delete(int id)
        {
            var db = new ClientData();
            db.Delete(id);
        }

        public Client GetById(int id)
        {
            var db = new ClientData();
            return db.GetById(id);
        }

        public void Insert(Client cli)
        {
            var db = new ClientData();
            db.Insert(cli);
        }

        public IEnumerable<Client> List()
        {
            var db = new ClientData();
            return db.List();
        }
        public void Update(Client cli)
        {
            var db = new ClientData();
            db.Update(cli);
        }
    }
}
