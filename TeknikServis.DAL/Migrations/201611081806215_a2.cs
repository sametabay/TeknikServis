namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markalar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MarkaAdi = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Fotograflar", "MarkaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Fotograflar", "MarkaID");
            AddForeignKey("dbo.Fotograflar", "MarkaID", "dbo.Markalar", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotograflar", "MarkaID", "dbo.Markalar");
            DropIndex("dbo.Fotograflar", new[] { "MarkaID" });
            DropColumn("dbo.Fotograflar", "MarkaID");
            DropTable("dbo.Markalar");
        }
    }
}
