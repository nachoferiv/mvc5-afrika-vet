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
    public class RoomBLL : IRepository<Room>
    {
        public void Delete(int id)
        {
            var db = new RoomData();
            db.Delete(id);
        }

        public Room GetById(int id)
        {
            var db = new RoomData();
            return db.GetById(id);
        }

        public void Insert(Room room)
        {
            var db = new RoomData();
            db.Insert(room);
        }

        public IEnumerable<Room> List()
        {
            var db = new RoomData();
            return db.List();
        }
        public void Update(Room room)
        {
            var db = new RoomData();
            db.Update(room);
        }
    }
}
