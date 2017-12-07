using OnIt.Task.Command;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Windows;
using System.Windows.Input;

namespace OnIt.Task.View
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private MainWindowCommand command;
      public MainWindow()
      {
         InitializeComponent();

         command = new MainWindowCommand();
         DataContext = command;
      }

      public void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
      {
         command.EditTask(sender);
      }
   }
}
