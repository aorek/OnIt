using OnIt.Model;
using OnIt.Model.Repository;
using OnIt.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;
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
         DataContext = new MainViewModel();
         InitializeComponent();
      }
   }
}
