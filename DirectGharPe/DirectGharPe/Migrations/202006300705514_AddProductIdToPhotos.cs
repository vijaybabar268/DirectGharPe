namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductIdToPhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "PhotoUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Photos", "PhotoThumbUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "PhotoThumbUrl", c => c.String());
            AlterColumn("dbo.Photos", "PhotoUrl", c => c.String());
            DropColumn("dbo.Photos", "ProductId");
        }
    }
}
