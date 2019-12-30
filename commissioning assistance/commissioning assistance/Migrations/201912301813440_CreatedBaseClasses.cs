namespace commissioning_assistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedBaseClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstagramCommissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instagram = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Money = c.Single(nullable: false),
                        CurrencyType = c.String(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        FinishedDate = c.DateTime(nullable: false),
                        ProductType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_Id)
                .Index(t => t.ProductType_Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        InstagramCommission_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InstagramCommissions", t => t.InstagramCommission_Id)
                .Index(t => t.InstagramCommission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "InstagramCommission_Id", "dbo.InstagramCommissions");
            DropForeignKey("dbo.InstagramCommissions", "ProductType_Id", "dbo.ProductTypes");
            DropIndex("dbo.ImageModels", new[] { "InstagramCommission_Id" });
            DropIndex("dbo.InstagramCommissions", new[] { "ProductType_Id" });
            DropTable("dbo.ImageModels");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.InstagramCommissions");
        }
    }
}
