using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetManagement.Core.Model;
using System.Data.Entity;



namespace VetProject.Data
{
    public class VetDbContext : DbContext
    {
        public VetDbContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


    }
}