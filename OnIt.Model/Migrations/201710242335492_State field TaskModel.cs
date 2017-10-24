namespace OnIt.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatefieldTaskModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TASK", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TASK", "State");
        }
    }
}
