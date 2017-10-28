using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assessment.Gui.ViewModels.Base;
using Assessment.Web;
using Assessment.Dto;

namespace Assessment.Gui.ViewModels
{
    public class ClientViewModel: BaseViewModel
    {
        public string GivenName { get; set; }

        // NB Not required. Some people only have one name.
        public string FamilyName { get; set; }

        public int? GenderCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Contact CellPhone { get; set; }

        public Contact WorkPhone { get; set; }

        public List<Contact> OtherContacts { get; } = new List<Contact>();

        public Address PhysicalAddress { get; set; }

        public Address PostalAddress { get; set; }

        public List<Address> OtherAddresses { get; } = new List<Address>();        

        public static ClientViewModel FromDataModel(Client dto)
        {
            var model = new ClientViewModel
            {
                DateOfBirth = dto.DateOfBirth,
                FamilyName = dto.FamilyName,
                GenderCode = dto.GenderId,
                GivenName = dto.GivenName,
                // NB Contacts.
            };

            ////model.PhysicalAddress = dto.Addresses.SingleOrDefault(c => c.AddressType == PhysicalAddressType);

            return model;
        }
    }
}
