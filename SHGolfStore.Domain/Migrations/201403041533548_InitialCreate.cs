namespace SHGolfStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDesc = c.String(),
                        Brand = c.String(),
                        Category = c.String(),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
