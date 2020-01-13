namespace commissioning_assistance.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Added_CommissionFinished_Boolean : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstagramCommissions", "Finished", c => c.Boolean(nullable: false, defaultValueSql: "0"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstagramCommissions", "Finished");
        }
    }
}
