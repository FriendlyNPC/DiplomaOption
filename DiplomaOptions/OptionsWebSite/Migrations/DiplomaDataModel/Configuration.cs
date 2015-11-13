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
            context.SaveChanges();
            context.Options.AddOrUpdate(
                o => new { o.Title },
                new Option()
                {
                    Title = "Data Communications",
                    IsActive = true
                },
                new Option()
                {
                    Title = "Client Server",
                    IsActive = true
                },
                new Option()
                {
                    Title = "Digital Processing",
                    IsActive = true
                },
                new Option()
                {
                    Title = "Information Systems",
                    IsActive = true
                },
                new Option()
                {
                    Title = "Database",
                    IsActive = false
                },
                new Option()
                {
                    Title = "Web & Mobile",
                    IsActive = true
                },
                new Option()
                {
                    Title = "Tech Pro",
                    IsActive = false
                }
            );
            context.SaveChanges();

            context.Choices.AddOrUpdate(
                            o => new { o.StudentId, o.YearTermId },
                            new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555560",
                                StudentFirstName = "Jason",
                                StudentLastName = "Wronger",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }
                            , new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555551",
                                StudentFirstName = "Adam",
                                StudentLastName = "Harry",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555552",
                                StudentFirstName = "Spero",
                                StudentLastName = "Wong",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555553",
                                StudentFirstName = "Gotham",
                                StudentLastName = "Salamander",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555554",
                                StudentFirstName = "Salamander",
                                StudentLastName = "Jones",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555555",
                                StudentFirstName = "Jerry",
                                StudentLastName = "Springer",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555556",
                                StudentFirstName = "Megan",
                                StudentLastName = "Rain",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555557",
                                StudentFirstName = "Petrone",
                                StudentLastName = "Jimmy",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555558",
                                StudentFirstName = "Bobby",
                                StudentLastName = "Shine",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2015 && y.Term == 30).First().YearTermId,
                                StudentId = "A00555559",
                                StudentFirstName = "Mel",
                                StudentLastName = "Gibson",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444440",
                                StudentFirstName = "Smith",
                                StudentLastName = "Wrangler",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444441",
                                StudentFirstName = "Terry",
                                StudentLastName = "Fox",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444442",
                                StudentFirstName = "Nerjel",
                                StudentLastName = "Durik",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444443",
                                StudentFirstName = "Vajimer",
                                StudentLastName = "Sikh",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444444",
                                StudentFirstName = "Zimbobway",
                                StudentLastName = "Jones",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444445",
                                StudentFirstName = "Jerry",
                                StudentLastName = "Seinfeld",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444446",
                                StudentFirstName = "Jessica",
                                StudentLastName = "Andrews",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444447",
                                StudentFirstName = "Samantha",
                                StudentLastName = "Jimmy",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Web & Mobile").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444448",
                                StudentFirstName = "Bobby",
                                StudentLastName = "Billy Bob",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Tech Pro").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Database").First().OptionId
                            }, new Choice
                            {
                                YearTermId = context.YearTerms.Where(y => y.Year == 2016 && y.Term == 10).First().YearTermId,
                                StudentId = "A00444449",
                                StudentFirstName = "Jaysung",
                                StudentLastName = "Hignag",
                                SelectionDate = DateTime.Now,
                                FirstChoiceOptionId = context.Options.Where(o => o.Title == "Data Communications").First().OptionId,
                                SecondChoiceOptionId = context.Options.Where(o => o.Title == "Client Server").First().OptionId,
                                ThirdChoiceOptionId = context.Options.Where(o => o.Title == "Digital Processing").First().OptionId,
                                FourthChoiceOptionId = context.Options.Where(o => o.Title == "Information Systems").First().OptionId
                            }
                        );
            
            context.SaveChanges();
        }
    }
}
