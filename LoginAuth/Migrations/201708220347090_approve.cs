namespace LoginAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploads", "approve", c => c.Boolean());
        }
        
        public override void Down()
        {
        }
    }
}
