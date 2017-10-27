using Assessment.Dto;

namespace Assessment.Gui.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string GivenName { get; set; }

        [StringLength(100)]
        public string FamilyName { get; set; }

        public Gender GenderCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }
    }
}
