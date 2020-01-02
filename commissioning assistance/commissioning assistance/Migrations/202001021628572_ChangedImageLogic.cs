namespace commissioning_assistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedImageLogic : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageModels", "InstagramCommission_Id", "dbo.InstagramCommissions");
            DropIndex("dbo.ImageModels", new[] { "InstagramCommission_Id" });
            RenameColumn(table: "dbo.ImageModels", name: "InstagramCommission_Id", newName: "CommissionId");
            AlterColumn("dbo.ImageModels", "CommissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.ImageModels", "CommissionId");
            AddForeignKey("dbo.ImageModels", "CommissionId", "dbo.InstagramCommissions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "CommissionId", "dbo.InstagramCommissions");
            DropIndex("dbo.ImageModels", new[] { "CommissionId" });
            AlterColumn("dbo.ImageModels", "CommissionId", c => c.Int());
            RenameColumn(table: "dbo.ImageModels", name: "CommissionId", newName: "InstagramCommission_Id");
            CreateIndex("dbo.ImageModels", "InstagramCommission_Id");
            AddForeignKey("dbo.ImageModels", "InstagramCommission_Id", "dbo.InstagramCommissions", "Id");
        }
    }
}
