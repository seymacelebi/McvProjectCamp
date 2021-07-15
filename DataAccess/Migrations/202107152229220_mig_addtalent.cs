namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addtalent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        TalentName = c.String(),
                        Range = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TalentId);
            
            AddColumn("dbo.Admins", "Mail", c => c.String());
            AddColumn("dbo.Admins", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserNameSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserNameHash", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminUserNameHash");
            DropColumn("dbo.Admins", "AdminUserNameSalt");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Admins", "Status");
            DropColumn("dbo.Admins", "Mail");
            DropTable("dbo.Talents");
        }
    }
}
