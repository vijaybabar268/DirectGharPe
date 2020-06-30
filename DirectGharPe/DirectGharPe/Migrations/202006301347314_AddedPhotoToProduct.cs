namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhotoToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PhotoId", c => c.Int());
            CreateIndex("dbo.Products", "PhotoId");
            AddForeignKey("dbo.Products", "PhotoId", "dbo.Photos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Products", new[] { "PhotoId" });
            DropColumn("dbo.Products", "PhotoId");
        }
    }
}
