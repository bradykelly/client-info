using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Windows.Input;

namespace Assessment.Gui.ViewModels.Base
{
    public class BaseViewModel
    {
        // NB Update others for same word structure.
        public const string PhysicalAddressType = "Physical";
        public const string PostalAddressType = "Postal";
        public const string PhoneTypeCell = "CellPhone";

        [Key]
        public int Id { get; set; }
    }
}
