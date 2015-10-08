namespace DiplomaDataModel.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DiplomaDataModel : DbContext
    {
        // Your context has been configured to use a 'DiplomaDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DiplomaDataModel.Models.DiplomaDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DiplomaDataModel' 
        // connection string in the application configuration file.
        public DiplomaDataModel()
            : base("name=DiplomaDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<YearTerm> YearTerms { get; set; }

    }

    public class Choice
    {
        public int ChoiceId { get; set; }
        public int YearTermId { get; set; }
        public string StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int FirstChoiceOptionId { get; set; }
        public int SecondChoiceOptionId { get; set; }
        public int FourthChoiceOptionId { get; set; }
        public DateTime SelectionDate { get; set; }
    }

    public class Option
    {
        public int OptionId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }

    public class YearTerm
    {
        public int YearTermId { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public bool IsDefault { get; set; }
    }


}