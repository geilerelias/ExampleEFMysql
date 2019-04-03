namespace LayerInfraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MysqlContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Imagen = c.Binary(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Phone = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Address = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        State = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "CountryId", "dbo.Country");
            DropIndex("dbo.Person", new[] { "CountryId" });
            DropTable("dbo.Person");
            DropTable("dbo.Country");
        }
    }
}
