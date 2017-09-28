using OnIt.Model;
using OnIt.MVVM;
using System.Collections.ObjectModel;

namespace OnIt.ViewModel
{
   public class MainViewModel : NotifyPropertyChanged
   {
      private ObservableCollection<TaskModel> tasks;

      public ObservableCollection<TaskModel> Tasks
      {
         get { return tasks; }
         set
         {
            if (value != tasks)
            {
               tasks = value;
               OnPropertyChanged(nameof(Tasks));
            }
         }
      }

      public MainViewModel()
      {
         Tasks = new ObservableCollection<TaskModel>
         {
            new TaskModel { Title = "Hacer la cama", Desc = "Cambiar las sabanas" },
            new TaskModel { Title = "Hacer la comida", Desc = "De postre un bizcocho" },
            new TaskModel { Title = "Ir al médico", Desc = "Revisión completa" }
         };
      }
   }
}
