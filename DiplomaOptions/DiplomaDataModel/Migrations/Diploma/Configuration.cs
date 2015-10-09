namespace DiplomaDataModel.Migrations.Diploma
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaDataModel.Models.DiplomaDataModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Diploma";
        }

        protected override void Seed(DiplomaDataModel.Models.DiplomaDataModelContext context)
        {
            List<YearTerm> yearTerms = new List<YearTerm>();

            yearTerms.Add(new YearTerm()
            {
                Year = 2015,
                Term = 10,
                IsDefault = false
            });
            yearTerms.Add(new YearTerm()
            {
                Year = 2015,
                Term = 20,
                IsDefault = false
            });
            yearTerms.Add(new YearTerm()
            {
                Year = 2015,
                Term = 30,
                IsDefault = false
            });
            yearTerms.Add(new YearTerm()
            {
                Year = 2016,
                Term = 10,
                IsDefault = true
            });

            context.YearTerms.AddRange(yearTerms);
            context.SaveChanges();

            List<Option> options = new List<Option>();

            options.Add(new Option()
            {
                Title = "Data Communications",
                IsActive = true
            });

            options.Add(new Option()
            {
                Title = "Client Server",
                IsActive = true
            });
            options.Add(new Option()
            {
                Title = "Digital Processing",
                IsActive = true
            });
            options.Add(new Option()
            {
                Title = "Information Systems",
                IsActive = true
            });
            options.Add(new Option()
            {
                Title = "Database",
                IsActive = false
            });
            options.Add(new Option()
            {
                Title = "Web & Mobile",
                IsActive = true
            });
            options.Add(new Option()
            {
                Title = "Tech Pro",
                IsActive = false
            });

            context.Options.AddRange(options);
            context.SaveChanges();

        }
    }
}
