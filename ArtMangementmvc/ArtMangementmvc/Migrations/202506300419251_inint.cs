namespace ArtMangementmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        CustomerTypeId = c.Int(nullable: false, identity: true),
                        CustomerTypeName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        InvoiceNo = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        CustomerTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.CustomerTypes", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.SaleDetailes",
                c => new
                    {
                        SaleDetaileId = c.Int(nullable: false, identity: true),
                        ArtName = c.String(),
                        Quantity = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleDetaileId)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetailes", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.SaleDetailes", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "CustomerTypeId" });
            DropTable("dbo.SaleDetailes");
            DropTable("dbo.Sales");
            DropTable("dbo.CustomerTypes");
        }
    }
}
