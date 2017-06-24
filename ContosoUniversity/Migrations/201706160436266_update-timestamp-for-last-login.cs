namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetimestampforlastlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastLoginTime", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "timeCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "timeCreated", c => c.String());
            DropColumn("dbo.AspNetUsers", "LastLoginTime");
        }
    }
}
