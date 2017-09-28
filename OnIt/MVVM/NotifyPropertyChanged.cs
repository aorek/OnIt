using System.ComponentModel;

namespace OnIt.MVVM
{
   public class NotifyPropertyChanged : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }
   }
}
