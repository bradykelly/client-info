using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assessment.Entities.Base;

namespace Assessment.Entities
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