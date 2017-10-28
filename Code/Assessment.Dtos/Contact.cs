using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assessment.Dtos.Base;

namespace Assessment.Dtos
{
    [Table(nameof(Contact))]
    public class Contact: BaseEntity
    {
        [StringLength(20)]
        public string ContactType { get; set; } 

        [StringLength(50)]
        public string ContactDetail { get; set; }
    }
}