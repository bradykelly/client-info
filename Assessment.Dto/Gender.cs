using System.ComponentModel.DataAnnotations;
using Assessment.Dto.Base;

namespace Assessment.Dto
{
    public class Gender: BaseEntity
    {
        public Gender()
        {            
        }

        public Gender(char code, string name)
        {            
        }

        public char Code { get; set; }

        public string Name { get; set; }    
    }
}
