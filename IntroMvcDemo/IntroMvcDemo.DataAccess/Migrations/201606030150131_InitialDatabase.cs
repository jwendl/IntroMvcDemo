namespace IntroMvcDemo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ArtistId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        Duration = c.Time(nullable: false, precision: 7),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(maxLength: 64),
                        TinySongLink = c.String(maxLength: 64),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        StreetAddress = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        ZipCode = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderSongs",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Song_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Song_Id })
                .ForeignKey("dbo.Order", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Song", t => t.Song_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Song_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderSongs", "Song_Id", "dbo.Song");
            DropForeignKey("dbo.OrderSongs", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropIndex("dbo.OrderSongs", new[] { "Song_Id" });
            DropIndex("dbo.OrderSongs", new[] { "Order_Id" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Song", new[] { "AlbumId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropTable("dbo.OrderSongs");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.Song");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
