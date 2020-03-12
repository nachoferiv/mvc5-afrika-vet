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
    public class PatientBLL : IRepository<Patient>
    {
        public void Delete(int id)
        {
            var db = new PatientData();
            db.Delete(id);
        }

        public Patient GetById(int id)
        {
            var db = new PatientData();
            return db.GetById(id);
        }

        public void Insert(Patient patient)
        {
            var db = new PatientData();
            db.Insert(patient);
        }

        public IEnumerable<Patient> List()
        {
            var db = new PatientData();
            return db.List();
        }
        public void Update(Patient patient)
        {
            var db = new PatientData();
            db.Update(patient);
        }
    }
}
