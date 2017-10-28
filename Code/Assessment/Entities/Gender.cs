using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Entities.Base;

namespace Assessment.Entities
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
