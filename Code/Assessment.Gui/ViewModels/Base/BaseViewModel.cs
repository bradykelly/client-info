using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assessment.Gui.Annotations;

namespace Assessment.Gui.ViewModels.Base
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        // NB Update others for same word structure.
        public const string PhysicalAddressType = "Physical";
        public const string PostalAddressType = "Postal";
        public const string PhoneTypeCell = "CellPhone";

        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
