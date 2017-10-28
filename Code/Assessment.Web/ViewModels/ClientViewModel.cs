using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Assessment.Dto;
using Assessment.Web.Models;
using Assessment.Web.ViewModels.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assessment.Web.ViewModels
{
    public class ClientViewModel: BaseViewModel
    {
        public ClientViewModel()
        {
            GendersList = new SelectList(ClientModel.GenderModels.Where(m => m.Id != (int)Genders.Withheld), "Id", "Name");
        }

        [Required]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        // NB Not required. Some people only have one name.
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int? GenderId { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Cell Phone")]
        public Contact CellPhone { get; set; }

        [Display(Name = "Work Phone")]
        public Contact WorkPhone { get; set; }

        public SelectList GendersList { get; set; }

        public List<Contact> OtherContacts { get; } = new List<Contact>();

        public Address PhysicalAddress { get; set; }

        public Address PostalAddress { get; set; }

        public List<Address> OtherAddresses { get; } = new List<Address>();        

        public static ClientViewModel FromDataModel(Client dto)
        {
            var model = new ClientViewModel();
            model.Id = dto.Id;
            model.DateOfBirth = dto.DateOfBirth.ToString("yyyy-MM-dd");
            model.FamilyName = dto.FamilyName;
            model.GenderId = dto.GenderId;
            model.GivenName = dto.GivenName;
            model.CellPhone = dto.Contacts.SingleOrDefault(c => c.ContactType == PhoneTypeCell);

            model.PhysicalAddress = dto.Addresses.SingleOrDefault(c => c.AddressType == AddressTypePhysical);

            return model;
        }
    }
}
