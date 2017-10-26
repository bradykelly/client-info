﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assessment.Dto;
using Assessment.Gui.ViewModels.Base;

namespace Assessment.Gui.ViewModels
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

        public static ClientViewModel FromDataModel(Dto.Client dto)
        {
            var model = new ClientViewModel
            {
                DateOfBirth = dto.DateOfBirth,
                FamilyName = dto.FamilyName,
                GenderId = dto.GenderId,
                GivenName = dto.GivenName,
                CellPhone = dto.Contacts.SingleOrDefault(c => c.ContactType == PhoneTypeCell)
            };

            model.PhysicalAddress = dto.Addresses.SingleOrDefault(c => c.AddressType == PhysicalAddressType);

            return model;
        }
    }
}
