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
    public class AppointmentBLL : IRepository<Appointment>
    {
        public void Delete(int id)
        {
            var db = new AppointmentData();
            db.Delete(id);
        }

        public Appointment GetById(int id)
        {
            var db = new AppointmentData();
            return db.GetById(id);
        }

        public void Insert(Appointment app)
        {
            var db = new AppointmentData();
            db.Insert(app);
        }

        public IEnumerable<Appointment> List()
        {
            var db = new AppointmentData();
            return db.List();
        }
        public void Update(Appointment app)
        {
            var db = new AppointmentData();
            db.Update(app);
        }

        public string ValidationCheck(Appointment app)
        {
            var db = new AppointmentData();
            return db.ValidationCheck(app);
        }
    }
}
