using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assessment.Wpf.Annotations;

namespace Assessment.Wpf.ViewModels.Base
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public const string AddressTypePhysical = "Physical";
        public const string AddressTypePostal = "Postal";
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
