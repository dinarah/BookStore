namespace BooksStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsCover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Cover", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Cover");
        }
    }
}
