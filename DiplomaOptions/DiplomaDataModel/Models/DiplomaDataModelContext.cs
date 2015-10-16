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
            : base("DiplomaContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<YearTerm> YearTerms { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        
    }

    

   

    

    

    


}