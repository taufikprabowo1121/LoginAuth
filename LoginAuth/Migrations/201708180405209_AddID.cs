namespace LoginAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploads", "UserId", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
