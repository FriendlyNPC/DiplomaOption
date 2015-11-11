namespace OptionsWebSite.Migrations.DiplomaDataModel
{
    using global::DiplomaDataModel.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaDataModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DiplomaDataModel";
        }

        protected override void Seed(DiplomaDataModelContext context)
        {
            context.YearTerms.AddOrUpdate(
             y => new { y.Year, y.Term },
             new YearTerm
             {
                 Year = 2015,
                 Term = 10,
                 IsDefault = false
             },
             new YearTerm
             {
                 Year = 2015,
                 Term = 20,
                 IsDefault = false
             },
             new YearTerm
             {
                 Year = 2015,
                 Term = 30,
                 IsDefault = false
             },
             new YearTerm
             {
                 Year = 2016,
                 Term = 10,
                 IsDefault = true
             }
         );

            
            context.Options.AddOrUpdate(
                o => new { o.Title },
                new Option
                {
                    Title = "Data Communications",
                    IsActive = true
                },
                new Option
                {
                    Title = "Client Server",
                    IsActive = true
                },
                new Option
                {
                    Title = "Digital Processing",
                    IsActive = true
                },
                new Option
                {
                    Title = "Information Systems",
                    IsActive = true
                },
                new Option
                {
                    Title = "Database",
                    IsActive = false
                },
                new Option
                {
                    Title = "Web & Mobile",
                    IsActive = true
                },
                new Option
                {
                    Title = "Tech Pro",
                    IsActive = false
                }
            );

            context.SaveChanges();
            //add seeded choices
            /*
            context.Choices.AddOrUpdate(
                o => new { o.StudentId, o.YearTermId },
                new Choice
                {
                    YearTerm = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 30).First(),
                    YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 30).First().YearTermId,
                    StudentId = "A00123456",
                    StudentFirstName = "",
                    StudentLastName = "",
                    SelectionDate = new DateTime(),
                    Option1 = context.Options.Where(o => o.Title == "").First(),
                    Option2 = context.Options.Where(o => o.Title == "").First(),
                    Option3 = context.Options.Where(o => o.Title == "").First(),
                    Option4 = context.Options.Where(o => o.Title == "").First(),
                    FirstChoiceOptionId = context.Options.Where(o => o.Title == "").First().OptionId,
                    SecondChoiceOptionId = context.Options.Where(o => o.Title == "").First().OptionId,
                    ThirdChoiceOptionId = context.Options.Where(o => o.Title == "").First().OptionId,
                    FourthChoiceOptionId = context.Options.Where(o => o.Title == "").First().OptionId
                }
            );
            */

            context.SaveChanges();

        }
    }
}
