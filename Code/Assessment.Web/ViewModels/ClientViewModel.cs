using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Dto;
using Assessment.Web.ViewModels.Base;

namespace Assessment.Web.ViewModels
{
    public class ClientViewModel: BaseViewModel
    {
        public string GivenName { get; set; }

        // NB Not required. Some people only have one name.
        public string FamilyName { get; set; }

        public int? GenderId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Contact CellPhone { get; set; }

        public Contact WorkPhone { get; set; }

        public List<Contact> OtherContacts { get; } = new List<Contact>();

        public Address PhysicalAddress { get; set; }

        public Address PostalAddress { get; set; }

        public List<Address> OtherAddresses { get; } = new List<Address>();        

        public static ClientViewModel FromDataModel(Client dto)
        {
            var model = new ClientViewModel();
            model.Id = dto.Id;
            model.DateOfBirth = dto.DateOfBirth;
            model.FamilyName = dto.FamilyName;
            model.GenderId = dto.GenderId;
            model.GivenName = dto.GivenName;
            model.CellPhone = dto.Contacts.SingleOrDefault(c => c.ContactType == PhoneTypeCell);

            model.PhysicalAddress = dto.Addresses.SingleOrDefault(c => c.AddressType == AddressTypePhysical);

            return model;
        }
    }
}
