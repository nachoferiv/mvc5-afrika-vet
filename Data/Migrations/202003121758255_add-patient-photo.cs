namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpatientphoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "ImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ImgPath");
        }
    }
}
