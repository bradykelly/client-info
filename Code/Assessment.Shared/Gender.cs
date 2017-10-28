using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
using Assessment.Dto.Base;

namespace Assessment.Dto
{
    public class Gender: BaseEntity
    {
        public string Name { get; set; }
    }
}
