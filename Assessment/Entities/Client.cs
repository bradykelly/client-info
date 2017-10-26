using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assessment.Entities.Base;
using Assessment.Dtos;

namespace Assessment.Entities
{
    [Table(nameof(Client))]
    public class Client: BaseEntity
    {
        [Required]
        [StringLength(MaxNameLength)]
        public string GivenName { get; set; }

        // Not required. Some people only have one name.
        [StringLength(MaxNameLength)]
        public string FamilyName { get; set; }

        public Gender Gender { get; set; }

        [ForeignKey(nameof(Gender))]          
        public int GenderId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public List<Address> Addresses { get; } = new List<Address>();

        EmailAddressAttribute 
    }
}