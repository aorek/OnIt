namespace OnIt.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriorityDueTimeFieldsTaskModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TASK", "Description", c => c.String(maxLength: 100));
            AddColumn("dbo.TASK", "Priority", c => c.Int(nullable: false));
            AddColumn("dbo.TASK", "DueDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.TASK", "Title", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.TASK", "CreationDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            CreateIndex("dbo.TASK", "IdTask");
            DropColumn("dbo.TASK", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TASK", "Desc", c => c.String(maxLength: 100));
            DropIndex("dbo.TASK", new[] { "IdTask" });
            AlterColumn("dbo.TASK", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TASK", "Title", c => c.String(maxLength: 25));
            DropColumn("dbo.TASK", "DueDate");
            DropColumn("dbo.TASK", "Priority");
            DropColumn("dbo.TASK", "Description");
        }
    }
}
