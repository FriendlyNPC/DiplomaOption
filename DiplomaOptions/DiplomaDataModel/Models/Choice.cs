using DiplomaDataModel.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Models
{
    [Table("Choice")]
    public class Choice
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ChoiceId { get; set; }

        public int YearTermId { get; set; }
        [ForeignKey("YearTermId")]
        public YearTerm YearTerm { get; set; }

        [Required, MaxLength(9), StudentNumFormat]
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }

        [Required, MaxLength(40)]
        [Display(Name = "First Name")]
        public string StudentFirstName { get; set; }

        [Required, MaxLength(40)]
        [Display(Name = "Last Name")]
        public string StudentLastName { get; set; }

        [Required]
        [Display(Name = "First Choice")]
        public int FirstChoiceOptionId { get; set; }
        [Required]
        [Display(Name = "Second Choice")]
        public int SecondChoiceOptionId { get; set; }
        [Required]
        [Display(Name = "Third Choice")]
        public int ThirdChoiceOptionId { get; set; }
        [Required]
        [Display(Name = "Fourth Choice")]
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
        [Display(Name = "Selection Date")]
        public DateTime SelectionDate { get; set; }
    }
}
