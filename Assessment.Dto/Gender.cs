using System.ComponentModel.DataAnnotations;
using Assessment.Dto.Base;

namespace Assessment.Dto
{
    public class Gender: BaseEntity
    {
        public char Code { get; set; }

        public string Name { get; set; }    
    }
}
