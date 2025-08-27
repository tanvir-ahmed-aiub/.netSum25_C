namespace CFEFAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StuColAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Address", c => c.String(nullable: false, maxLength: 500, unicode: false));
            AlterColumn("dbo.Students", "Cgpa", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Cgpa", c => c.Single(nullable: false));
            DropColumn("dbo.Students", "Address");
        }
    }
}
