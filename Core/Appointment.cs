using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;

namespace VetManagement.Core.Model

{
    public partial class Appointment : IEntity
    {  
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        
    }
    public partial class Appointment
    {
        [MetadataType(typeof(AppointmentMetadata))]
        public class AppointmentMetadata
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public int PatientId { get; set; }
            [Required]
            public int RoomId { get; set; }
            [Required]
            public int DoctorId { get; set; }
            [Required]
            [DataType(DataType.DateTime)]
            public DateTime StartDate { get; set; }
            [Required]
            [DataType(DataType.DateTime)]
            public DateTime EndDate { get; set; }
            [Required]
            [StringLength(100)]
            public string Description { get; set; }
        }
    }
}