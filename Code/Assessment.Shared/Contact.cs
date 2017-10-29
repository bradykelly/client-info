using Assessment.Dto.Base;

namespace Assessment.Dto
{
    public class Contact: BaseEntity
    {
        public string ContactType { get; set; } 

        public string ContactDetail { get; set; }
    }
}