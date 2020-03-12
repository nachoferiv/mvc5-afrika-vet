using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VetManagement.Core.Interfaces;

namespace VetManagement.Core.Model
{
    public partial class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime EntryDate { get; set; }

    }
    [MetadataType(typeof(DoctorMetadata))]
    public partial class Doctor
    {
        public class DoctorMetadata
        {
            [Key]
            public int Id { get; set; }
            [StringLength(50)]
            [Required]
            public string Name { get; set; }
            [StringLength(50)]
            [Required]
            public string LastName { get; set; }
            [EmailAddress]
            [Required]
            public string Email { get; set; }
            [Phone]
            [Required]
            public string PhoneNumber { get; set; }
            [StringLength(50)]
            [Required]
            public string Address { get; set; }
            [DataType(DataType.Date)]
            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime EntryDate { get; set; }
        }
    }
}