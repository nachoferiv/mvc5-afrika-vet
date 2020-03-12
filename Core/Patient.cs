using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;

namespace VetManagement.Core.Model
{
    public partial class Patient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public Client Owner { get; set; }
        public Gender Gender { get; set; }
        public string ImgPath { get; set; }
    }
    public partial class Patient
    {
        public class PatientMetadata
        {
            [Key]
            public int Id { get; set; }
            [StringLength(50)]
            [Required]
            public string Name { get; set; }
            [Required]
            public int ClientId { get; set; }
            [Required]
            public Gender Gender { get; set; }
            [StringLength(int.MaxValue)]
            public string ImgPath { get; set; }
        }
    }
}