namespace BooksStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cover : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Cover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Cover", c => c.String());
        }
    }
}
