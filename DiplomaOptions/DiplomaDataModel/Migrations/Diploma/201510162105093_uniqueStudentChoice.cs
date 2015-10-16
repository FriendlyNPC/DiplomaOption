namespace DiplomaDataModel.Migrations.Diploma
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueStudentChoice : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Choice", "StudentId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Choice", new[] { "StudentId" });
        }
    }
}
