using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Assessment.Dtos.Base;

namespace Assessment.Dtos
{
    public class ClientViewModel: BaseViewModel
    {
        [Required]
        [StringLength(MaxNameLength)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        // Not required. Some people only have one name.
        [StringLength(MaxNameLength)]
        [Display(Name = "Given Name")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int? GenderId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public static ClientViewModel FromDataModel(Client )
    }
}
