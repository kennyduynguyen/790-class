namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusercolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "timeCreated");
            DropColumn("dbo.AspNetUsers", "LastLoginTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastLoginTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "timeCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "LastLogin");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
        }
    }
}
