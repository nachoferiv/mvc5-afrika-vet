using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;
using System.Data.Entity;


namespace VetProject.Data
{
    public class AppointmentData : IRepository<Appointment>
    {
        public IEnumerable<Appointment> List()
        {
            var appointments = new VetDbContext().Appointments.Include(p => p.Doctor).Include(p => p.Room).Include(p => p.Patient);
            return appointments.ToList();
        }
        public Appointment GetById(int id)
        {
            return new VetDbContext().Appointments.Find(id);
        }
        public void Insert(Appointment app)
        {
            var context = new VetDbContext();
            context.Appointments.Add(app);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var context = new VetDbContext();
            context.Appointments.Remove(context.Appointments.Find(id));
            context.SaveChanges();
        }
        public void Update(Appointment updated)
        {
            var context = new VetDbContext();
            var app = context.Appointments.Find(updated.Id);
            if (app != null)
            {
                app.PatientId = updated.PatientId;
                app.RoomId = updated.RoomId;
                app.DoctorId = updated.DoctorId;
                app.StartDate = updated.StartDate;
                app.EndDate = updated.EndDate;
                app.Description = updated.Description;      
            }
            context.SaveChanges();
        }

        public string ValidationCheck(Appointment app)
        {
            var context = new VetDbContext();
            var appointments = context.Appointments.Include(p => p.Doctor)
                                                    .Include(p => p.Room)
                                                    .Include(p => p.Patient)
                                                    .Where(i => i.StartDate == app.StartDate);
            string error = null;

            if (app.StartDate == app.EndDate)
            {
                error = "Start date can not be equal to End date.";
                return error;
            }
            if (app.StartDate > app.EndDate)
            {
                error = "Start date can not be grater than End date.";
                return error;
            }

            var hours = app.EndDate - app.StartDate;
            if (hours.Hours > 6)
            {
                error = "The appointments duration can not be grather than 6 hours.";
                return error;
            }

            if (app != null && appointments.Count() > 0)
            {
                if(appointments.Where(i => i.DoctorId == app.DoctorId).Count() > 0)
                {
                    error = "The doctor already has an appointment at the same time";
                    return error;
                }
                if (appointments.Where(i => i.RoomId == app.RoomId).Count() > 0)
                {
                    error = "The room is taken for the give time.";
                    return error;
                }
                if (appointments.Where(i => i.PatientId == app.PatientId).Count() > 0)
                {
                    error = "The patient already has an appointment at the same time";
                    return error;
                }
            }

            return error;
        }
    }
}
