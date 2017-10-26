using System.ComponentModel.DataAnnotations;
using Assessment.Dto.Base;

namespace Assessment.Dto
{
    public class Address: BaseEntity
    {
        public string AddressType { get; set; }

        public int ClientId { get; set; }

        public string UnitNo { get; set; }
        
        public string ComplexName { get; set; }

        public string StreetNo { get; set; }

        public string StreetName { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string PostalZipCode { get; set; }           
    }
}
