namespace HelloWorldSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "PhoneVietnam", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Email", c => c.String());
            AlterColumn("dbo.Admins", "PhoneVietnam", c => c.String());
            AlterColumn("dbo.Admins", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
        }
    }
}
