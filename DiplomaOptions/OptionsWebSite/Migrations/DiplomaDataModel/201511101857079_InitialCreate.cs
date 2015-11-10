namespace OptionsWebSite.Migrations.DiplomaDataModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choice",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        YearTermId = c.Int(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 9),
                        StudentFirstName = c.String(nullable: false, maxLength: 40),
                        StudentLastName = c.String(nullable: false, maxLength: 40),
                        FirstChoiceOptionId = c.Int(nullable: false),
                        SecondChoiceOptionId = c.Int(nullable: false),
                        ThirdChoiceOptionId = c.Int(nullable: false),
                        FourthChoiceOptionId = c.Int(nullable: false),
                        SelectionDate = c.DateTime(nullable: false),
                        Option_OptionId = c.Int(),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Option", t => t.Option_OptionId)
                .ForeignKey("dbo.Option", t => t.FirstChoiceOptionId, cascadeDelete: false)
                .ForeignKey("dbo.Option", t => t.SecondChoiceOptionId, cascadeDelete: false)
                .ForeignKey("dbo.Option", t => t.ThirdChoiceOptionId, cascadeDelete: false)
                .ForeignKey("dbo.Option", t => t.FourthChoiceOptionId, cascadeDelete: false)
                .ForeignKey("dbo.YearTerm", t => t.YearTermId, cascadeDelete: true)
                .Index(t => t.YearTermId)
                .Index(t => t.StudentId, unique: true)
                .Index(t => t.FirstChoiceOptionId)
                .Index(t => t.SecondChoiceOptionId)
                .Index(t => t.ThirdChoiceOptionId)
                .Index(t => t.FourthChoiceOptionId)
                .Index(t => t.Option_OptionId);
            
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId);
            
            CreateTable(
                "dbo.YearTerm",
                c => new
                    {
                        YearTermId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YearTermId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choice", "YearTermId", "dbo.YearTerm");
            DropForeignKey("dbo.Choice", "FourthChoiceOptionId", "dbo.Option");
            DropForeignKey("dbo.Choice", "ThirdChoiceOptionId", "dbo.Option");
            DropForeignKey("dbo.Choice", "SecondChoiceOptionId", "dbo.Option");
            DropForeignKey("dbo.Choice", "FirstChoiceOptionId", "dbo.Option");
            DropForeignKey("dbo.Choice", "Option_OptionId", "dbo.Option");
            DropIndex("dbo.Choice", new[] { "Option_OptionId" });
            DropIndex("dbo.Choice", new[] { "FourthChoiceOptionId" });
            DropIndex("dbo.Choice", new[] { "ThirdChoiceOptionId" });
            DropIndex("dbo.Choice", new[] { "SecondChoiceOptionId" });
            DropIndex("dbo.Choice", new[] { "FirstChoiceOptionId" });
            DropIndex("dbo.Choice", new[] { "StudentId" });
            DropIndex("dbo.Choice", new[] { "YearTermId" });
            DropTable("dbo.YearTerm");
            DropTable("dbo.Option");
            DropTable("dbo.Choice");
        }
    }
}
