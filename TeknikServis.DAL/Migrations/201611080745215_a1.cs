namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arizalar",
                c => new
                    {
                        ArizaID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 66),
                        Aciklama = c.String(),
                        Adres = c.String(),
                        Rapor = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        OnaylanmaTarihi = c.DateTime(),
                        OnarimTarihi = c.DateTime(),
                        KullaniciID = c.String(maxLength: 128),
                        OperatorID = c.String(maxLength: 128),
                        TeknisyenID = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArizaID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OperatorID)
                .ForeignKey("dbo.AspNetUsers", t => t.KullaniciID)
                .ForeignKey("dbo.AspNetUsers", t => t.TeknisyenID)
                .Index(t => t.KullaniciID)
                .Index(t => t.OperatorID)
                .Index(t => t.TeknisyenID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Fotograflar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Yol = c.String(nullable: false),
                        ArizaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arizalar", t => t.ArizaID, cascadeDelete: true)
                .Index(t => t.ArizaID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 35),
                        RegisterDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ActivationCode = c.String(),
                        PreRole = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Arizalar", "TeknisyenID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "KullaniciID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "OperatorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fotograflar", "ArizaID", "dbo.Arizalar");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Fotograflar", new[] { "ArizaID" });
            DropIndex("dbo.Arizalar", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Arizalar", new[] { "TeknisyenID" });
            DropIndex("dbo.Arizalar", new[] { "OperatorID" });
            DropIndex("dbo.Arizalar", new[] { "KullaniciID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Fotograflar");
            DropTable("dbo.Arizalar");
        }
    }
}
