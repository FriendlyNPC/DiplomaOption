using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Models
{
    [Table("YearTerm")]
    public class YearTerm
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Term")]
        public int YearTermId { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Term { get; set; }

        [Required, DefaultValueAttribute(false)]
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }

        public List<Choice> Choice { get; set; }
    }
}
