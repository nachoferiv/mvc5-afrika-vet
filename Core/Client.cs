using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VetManagement.Core.Model;
using VetManagement.Core.Interfaces;

namespace VetManagement.Core.Model

{
    public partial class Client : IEntity
    {
        public Client()
        {
            Patients = new List<Patient>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Patient> Patients { get; set; }
    }
    public partial class Client
    {
        [MetadataType(typeof(ClientMetadata))]
        public class ClientMetadata
        {
            [Key]
            public int Id { get; set; }
            [Required]
            [StringLength(50)]
            public string FullName { get; set; }
            [Required]
            [StringLength(50)]
            public string Email { get; set; }
            [Required]
            [Phone]
            public string PhoneNumber { get; set; }
        }
    }
}