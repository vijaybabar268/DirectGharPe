namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        PhotoThumbUrl = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Byte(),
                        Slug = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(),
                        DateModified = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId)
                .Index(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "PhotoId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.Photos");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
