namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentIdToBrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "ParentId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "ParentId");
        }
    }
}
