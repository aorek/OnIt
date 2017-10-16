using OnIt.Model;
using OnIt.Task.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OnIt
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      private void Application_Startup(object sender, StartupEventArgs e)
      {
         Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnItDbContext, OnIt.Model.Migrations.Configuration>());

         MainWindow mainWindow = new MainWindow();
         mainWindow.Show();
      }
   }
}
