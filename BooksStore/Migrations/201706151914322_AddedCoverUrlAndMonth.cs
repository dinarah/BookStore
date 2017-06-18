namespace BooksStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCoverUrlAndMonth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CoverUrl", c => c.String());
            AddColumn("dbo.Books", "Month", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Cover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Cover", c => c.String());
            DropColumn("dbo.Books", "Month");
            DropColumn("dbo.Books", "CoverUrl");
        }
    }
}
