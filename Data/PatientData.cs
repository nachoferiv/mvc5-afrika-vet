using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;
using System.Data.Entity;

namespace VetProject.Data
{
    public class PatientData : IRepository<Patient>
    {
        public IEnumerable<Patient> List()
        {
            var patients = new VetDbContext().Patients.Include(p => p.Owner);
            return patients.ToList();
        }
        public void Insert(Patient patient)
        {
            var context = new VetDbContext();
            context.Patients.Add(patient);
            context.SaveChanges();
        }
        public Patient GetById(int id)
        {
            var context = new VetDbContext();
            var patient = context.Patients.Include(p => p.Owner).ToList();
            return patient.Find(p => p.Id == id);
        }
        public void Delete(int id)
        {
            var context = new VetDbContext();
            var patient = context.Patients.Find(id);
            context.Patients.Remove(patient);
            context.SaveChanges();
        }
        public void Update(Patient updated)
        {
            var context = new VetDbContext();
            var patient = context.Patients.Find(updated.Id);
            if (!(patient is null))
            {
                patient.Name = updated.Name;
                patient.Gender = updated.Gender;
                patient.Owner = updated.Owner;
                patient.ClientId = updated.ClientId;
                patient.ImgPath = updated.ImgPath;
            }
            context.SaveChanges();
        }
    }
}