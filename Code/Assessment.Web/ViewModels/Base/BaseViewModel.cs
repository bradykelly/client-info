using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assessment.Web.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public const string AddressTypePhysical = "Physical";
        public const string AddressTypePostal = "Postal";
        public const string PhoneTypeCell = "CellPhone";

        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // TODO How to get this attribute back by manually adding ReSharper annotations.
        ////[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
