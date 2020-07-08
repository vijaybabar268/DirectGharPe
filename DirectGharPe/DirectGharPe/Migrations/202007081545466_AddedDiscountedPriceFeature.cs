namespace DirectGharPe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscountedPriceFeature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PriceBefore", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "Save", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Save");
            DropColumn("dbo.Products", "Discount");
            DropColumn("dbo.Products", "PriceBefore");
        }
    }
}
