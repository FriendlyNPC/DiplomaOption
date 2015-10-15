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
    [Table("Option")]
    public class Option
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OptionId { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required, DefaultValueAttribute(false)]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public List<Choice> Choice { get; set; }
        
    }

    
}
