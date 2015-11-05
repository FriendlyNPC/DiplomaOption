namespace OptionsWebSite.Migrations.DiplomaOptions
{
    using DiplomaDataModel.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaDataModel.Models.DiplomaDataModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\DiplomaOptions";
        }

        protected override void Seed(DiplomaDataModel.Models.DiplomaDataModelContext context)
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


            //add seeded choices
            /*
            context.Options.AddOrUpdate(
                o => new { o.Title },
                new Option
                {
                    Title = "Data Communications",
                    IsActive = true
                }
            }
            */

            context.SaveChanges();

        }
    }
}
