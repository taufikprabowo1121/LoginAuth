namespace LoginAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FileUploads", "FileSize");
        }
        
        public override void Down()
        {
        }
    }
}
