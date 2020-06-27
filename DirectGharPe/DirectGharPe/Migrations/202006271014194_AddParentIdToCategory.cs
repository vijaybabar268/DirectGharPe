namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentIdToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ParentId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ParentId");
        }
    }
}
