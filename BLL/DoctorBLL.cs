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
    public class DoctorBLL : IRepository<Doctor>
    {
        public void Delete(int id)
        {
            var db = new DoctorData();
            db.Delete(id);
        }

        public Doctor GetById(int id)
        {
            var db = new DoctorData();
            return db.GetById(id);
        }

        public void Insert(Doctor doc)
        {
            var db = new DoctorData();
            db.Insert(doc);
        }

        public IEnumerable<Doctor> List()
        {
            var db = new DoctorData();
            return db.List();
        }
        public void Update(Doctor doc)
        {
            var db = new DoctorData();
            db.Update(doc);
        }
    }
}
