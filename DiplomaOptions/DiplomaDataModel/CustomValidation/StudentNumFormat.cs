using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DiplomaDataModel.CustomValidation
{
    public class StudentNumFormat : ValidationAttribute
    {

        public StudentNumFormat() : base("{0} is not a valid student Id")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string sPattern = "^(a|A)00\\d{6}$";

                if ( !System.Text.RegularExpressions.Regex.IsMatch((string)value, sPattern) )
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}

