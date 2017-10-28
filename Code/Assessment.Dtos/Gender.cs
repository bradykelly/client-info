using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assessment.Dtos.Base;

namespace Assessment.Dtos
{
    [Table(nameof(Gender))]
    public class Gender: BaseEntity
    {
        // NB Test regex
        [Required]
        [RegularExpression("[FM]{1}")]
        public char Code { get; set; }

        [Required]
        public string Name { get; set; }    
    }
}
