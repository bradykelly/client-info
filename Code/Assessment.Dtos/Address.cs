using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assessment.Dtos.Base;

namespace Assessment.Dtos
{
    [Table(nameof(Address))]
    public class Address: BaseEntity
    {
        [StringLength(MaxCodeLength)]
        public string UnitNo { get; set; }
        
        [StringLength(MaxNameLength)]
        public string ComplexName { get; set; }

        [StringLength(MaxCodeLength)]
        public string StreetNo { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string City { get; set; }

        // Not required for physical address.
        [StringLength(MaxCodeLength)]
        public string PostalZipCode { get; set; }   
    }
}
