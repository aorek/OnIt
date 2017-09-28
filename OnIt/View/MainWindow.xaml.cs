using OnIt.Model;
using System;
using System.Windows;

namespace OnIt.View
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         using (var context = new OnItContext<TaskModel>())
         {
            var task = new TaskModel { Title = "Hacer la cama", Desc = "Cambiar las sabanas", CreationDate = DateTime.Now };
            context.Task.Add(task);
            context.SaveChanges();
         }
      }
   }
}
