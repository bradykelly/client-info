using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
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

        public static Gender FromCode(char genderCode)
        {
            switch (genderCode.ToString().ToUpper())
            {
                case "F":
                    return new Gender('F', "Female");
                case "M":
                    return new Gender('M', "Male");
                default:
                    throw new ArgumentOutOfRangeException(nameof(genderCode), "Gender Code must be 'F' or 'M'.");
            }
        }
    }
}
