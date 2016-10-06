namespace CarLookUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BodyTypeID = c.Int(nullable: false),
                        Maker = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BodyType", t => t.BodyTypeID, cascadeDelete: true)
                .Index(t => t.BodyTypeID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "BodyTypeID", "dbo.BodyType");
            DropIndex("dbo.Car", new[] { "BodyTypeID" });
            DropTable("dbo.Role");
            DropTable("dbo.Car");
            DropTable("dbo.BodyType");
        }
    }
}
