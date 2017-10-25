using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Model
{
   public class ConnectionSQLiteDBSingleton
   {
      public string DbName { get; set; }
      public string DbDirectory { get; set; }
      public string ConnectionString { get; set; }
      public DbConnection DbConnection { get; set; }

      private static ConnectionSQLiteDBSingleton instance;
      public static ConnectionSQLiteDBSingleton Instance
      {
         get
         {
            if (instance == null)
               instance = new ConnectionSQLiteDBSingleton();
            return instance;
         }
      }

      public ConnectionSQLiteDBSingleton()
      {
         DbName = "OnItDbContext";
         DbDirectory = "Data";
         DbConnection = GetLocalDB(DbName);
      }

      private SQLiteConnection GetLocalDB(string dbName, bool deleteIfExists = false)
      {
         try
         {
            string outputFolder = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), DbDirectory);
            string mdfFilename = dbName + ".sqlite";
            string dbFileName = Path.Combine(outputFolder, mdfFilename);
            string logFileName = Path.Combine(outputFolder, String.Format("{0}_log.ldf", dbName));
            // Create Data Directory If It Doesn't Already Exist.
            if (!Directory.Exists(outputFolder))
            {
               Directory.CreateDirectory(outputFolder);
            }

            // If the file exists, and we want to delete old data, remove it here and create a new database.
            if (File.Exists(dbFileName) && deleteIfExists)
            {
               if (File.Exists(logFileName)) File.Delete(logFileName);
               File.Delete(dbFileName);
               SQLiteConnection.CreateFile(dbFileName);
            }
            // If the database does not already exist, create it.
            else if (!File.Exists(dbFileName))
            {
               SQLiteConnection.CreateFile(dbFileName);
            }

            // Open newly created, or old database.
            ConnectionString = String.Format($"Data Source={dbFileName};");
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
         }
         catch
         {
            throw;
         }
      }

      private void FixEfProviderServicesProblem()
      {
         //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
         //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
         //Make sure the provider assembly is available to the running application. 
         //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

         var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
      }
   }
}
