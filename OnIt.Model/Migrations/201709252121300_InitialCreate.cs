namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        IdTask = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 25),
                        Desc = c.String(maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdTask);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Task");
        }
    }
}
