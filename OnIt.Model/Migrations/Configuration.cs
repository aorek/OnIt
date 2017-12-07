namespace OnIt.Model.Migrations
{
   using System;
   using System.Collections.Generic;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

   public sealed class Configuration : DbMigrationsConfiguration<OnIt.Model.OnItDbContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
         AutomaticMigrationDataLossAllowed = true;
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

         var initialTasks = new List<int>
         {
            1, 2, 3, 4, 5
         };

         if (!(context.TASK.Select(t => t.IdTask).Where(t => initialTasks.Any(iT => iT == t)).Count() == 5))
         {
            context.TASK.Add(new TaskModel { IdTask = 1, Title = "Despertar", Description = "Levantarse, ducha y desayuno", CreationDate = DateTime.Now, DueDate = DateTime.Now });
            context.TASK.Add(new TaskModel { IdTask = 2, Title = "Ir al médico", Description = "Analisis de sangre", CreationDate = DateTime.Now, DueDate = DateTime.Now });
            context.TASK.Add(new TaskModel { IdTask = 3, Title = "Trabajar", Description = "Terminar informe del mes", CreationDate = DateTime.Now, DueDate = DateTime.Now });
            context.TASK.Add(new TaskModel { IdTask = 4, Title = "Cita", Description = "He quedado con mi amigo Pepe", CreationDate = DateTime.Now, DueDate = DateTime.Now });
            context.TASK.Add(new TaskModel { IdTask = 5, Title = "Comida de mañana", Description = "Hacer la comida para mañana", CreationDate = DateTime.Now, DueDate = DateTime.Now });
         }

      }
   }
}
