namespace TTSHOP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "ParentID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "ParentID");
        }
    }
}
