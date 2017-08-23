namespace LoginAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.FileUploads",
             c => new
             {
                 ID = c.Int(nullable: false, identity: true),
                 FileName = c.String(),
                 FilePath = c.String(),
                 FileSize = c.String(),
             })
             .PrimaryKey(t => t.ID);
        }
        public override void Down()
        {
        }
    }
}
