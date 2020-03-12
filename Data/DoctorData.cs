using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;

namespace VetProject.Data
{
    public class DoctorData : IRepository<Doctor>
    {
        public void Delete(int id)
        {
            var db = new VetDbContext();
            var doc = db.Doctors.Find(id);
            db.Doctors.Remove(doc);
            db.SaveChanges();
        }

        public Doctor GetById(int id)
        {
            var db = new VetDbContext();
            return db.Doctors.Find(id);
        }
        public void Insert(Doctor doc)
        {
            var db = new VetDbContext();
            db.Doctors.Add(doc);
            db.SaveChanges();
        }
        public IEnumerable<Doctor> List()
        {
            var db = new VetDbContext();
            IEnumerable<Doctor> docs = db.Doctors.ToList();
            return docs;
        }
        public void Update(Doctor update)
        {
            var db = new VetDbContext();
            Doctor doc = db.Doctors.Find(update.Id);
            if (doc != null)
            {
                doc.Name = update.Name;
                doc.LastName = update.LastName;
                doc.Email = update.Email;
                doc.Address = update.Address;
                doc.PhoneNumber = update.PhoneNumber;
            }
            db.SaveChanges();
        }
    }
}