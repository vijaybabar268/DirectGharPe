namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideProductTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "PhotoId" });
            RenameColumn(table: "dbo.Products", name: "BrandId", newName: "Brand_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Products", "Category_Id", c => c.Int());
            AlterColumn("dbo.Products", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Products", "Brand_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brands", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Products", "PhotoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PhotoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            AlterColumn("dbo.Products", "Brand_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Brand_Id", newName: "BrandId");
            CreateIndex("dbo.Products", "PhotoId");
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
        }
    }
}
