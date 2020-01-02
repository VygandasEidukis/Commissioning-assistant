namespace commissioning_assistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedProductType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InstagramCommissions", new[] { "ProductType_ProductTypeId" });
            RenameColumn(table: "dbo.InstagramCommissions", name: "ProductType_ProductTypeId", newName: "ProductTypeId");
            AlterColumn("dbo.InstagramCommissions", "ProductTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.InstagramCommissions", "ProductTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InstagramCommissions", new[] { "ProductTypeId" });
            AlterColumn("dbo.InstagramCommissions", "ProductTypeId", c => c.Int());
            RenameColumn(table: "dbo.InstagramCommissions", name: "ProductTypeId", newName: "ProductType_ProductTypeId");
            CreateIndex("dbo.InstagramCommissions", "ProductType_ProductTypeId");
        }
    }
}
