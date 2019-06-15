namespace TTSHOP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentIDforProCate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "ParentID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "ParentID");
        }
    }
}
