namespace OnIt.Model.Migrations
{
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

   public sealed class Configuration : DbMigrationsConfiguration<OnIt.Model.OnItDbContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = false;
         ContextKey = "OnIt.Model.OnItContext";
      }

      protected override void Seed(OnIt.Model.OnItDbContext context)
      {
         //  This method will be called after migrating to the latest version.

         //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
         //  to avoid creating duplicate seed data. E.g.
         //
         //    context.People.AddOrUpdate(
         //      p => p.FullName,
         //      new Person { FullName = "Andrew Peters" },
         //      new Person { FullName = "Brice Lambson" },
         //      new Person { FullName = "Rowan Miller" }
         //    );
         //

         context.TASK.AddOrUpdate(
            new TaskModel { IdTask = 1, Title = "Hacer la cama", Desc = "Cambiar las sabanas", CreationDate = DateTime.Now },
            new TaskModel { IdTask = 2, Title = "Cagar", Desc = "Ir al baño", CreationDate = DateTime.Now },
            new TaskModel { IdTask = 3, Title = "Hacer la comida", Desc = "De postre un bizcocho", CreationDate = DateTime.Now },
            new TaskModel { IdTask = 4, Title = "Ir al médico", Desc = "Revisión completa", CreationDate = DateTime.Now }
         );

      }
   }
}
