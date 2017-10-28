using System.ComponentModel.DataAnnotations;

namespace Assessment.Dtos.Base
{
    public class BaseViewModel  
    {
        public const int MaxCodeLength = 10;
        public const int MaxNameLength = 100;
        public const int MaxDescLength = 500;

        [Key]
        public int Id { get; set; }
    }
}