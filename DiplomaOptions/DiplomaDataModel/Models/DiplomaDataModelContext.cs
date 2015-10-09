namespace DiplomaDataModel.Models
{
    using CustomValidation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;


    public class DiplomaDataModelContext : DbContext
    {
        // Your context has been configured to use a 'DiplomaDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DiplomaDataModel.Models.DiplomaDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DiplomaDataModel' 
        // connection string in the application configuration file.
        public DiplomaDataModelContext()
            : base("name=DiplomaDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<YearTerm> YearTerms { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }

    }




    [Table("Option")]
    public class Option
    {
        [Key]
        public int OptionId { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, DefaultValueAttribute(false)]
        public bool IsActive { get; set; }

        public List<Choice> Choice { get; set; }
    }
    [Table("YearTerm")]
    public class YearTerm
    {
        [Key]
        public int YearTermId { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Term { get; set; }
        [Required, DefaultValueAttribute(false)]
        public bool IsDefault { get; set; }

        public List<Choice> Choice { get; set; }
    }

    [Table("Choice")]
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        public int YearTermId { get; set; }
        [ForeignKey("YearTermId")]
        public YearTerm YearTerm {get; set;}

        [Required, MaxLength(9), StudentNumFormat ]
        public string StudentId { get; set; }
        [Required, MaxLength(40)]
        public string StudentFirstName { get; set; }
        [Required, MaxLength(40)]
        public string StudentLastName { get; set; }

        public int FirstChoiceOptionId { get; set; }
        public int SecondChoiceOptionId { get; set; }
        public int ThirdChoiceOptionId { get; set; }
        public int FourthChoiceOptionId { get; set; }

        [ForeignKey("FirstChoiceOptionId")]
        public Option Option1 { get; set; }

        [ForeignKey("SecondChoiceOptionId")]
        public Option Option2 { get; set; }

        [ForeignKey("ThirdChoiceOptionId")]
        public Option Option3 { get; set; }

        [ForeignKey("FourthChoiceOptionId")]
        public Option Option4 { get; set; }

        [Required]
        public DateTime SelectionDate { get; set; }


    }

    

    


}