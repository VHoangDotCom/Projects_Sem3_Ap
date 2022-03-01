namespace HelloWorldSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        PhoneVietnam = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
