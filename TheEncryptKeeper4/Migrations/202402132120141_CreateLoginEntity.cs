namespace TheEncryptKeeper4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLoginEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginEntities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Website = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginEntities");
        }
    }
}
