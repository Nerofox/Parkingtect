namespace dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EvenementImages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Libelle = c.String(),
                        Path = c.String(),
                        Evenement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evenements", t => t.Evenement_Id)
                .Index(t => t.Evenement_Id);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ville = c.String(),
                        Adresse = c.String(),
                        CodePostal = c.String(),
                        Theme = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvenementImages", "Evenement_Id", "dbo.Evenements");
            DropIndex("dbo.EvenementImages", new[] { "Evenement_Id" });
            DropTable("dbo.Evenements");
            DropTable("dbo.EvenementImages");
        }
    }
}
