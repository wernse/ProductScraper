namespace angularJS.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNewProductFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Store", c => c.String());
            AddColumn("dbo.Products", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Category");
            DropColumn("dbo.Products", "Store");
        }
    }
}
