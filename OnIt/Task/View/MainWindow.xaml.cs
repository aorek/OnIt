using OnIt.Task.Command;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Windows;

namespace OnIt.Task.View
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         DataContext = new MainWindowCommand();
      }
   }
}
