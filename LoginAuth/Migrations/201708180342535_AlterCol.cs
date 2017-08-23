namespace LoginAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FileUploads", "FileSize");
            // A("dbo.Movies", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            
        }
    }
}
