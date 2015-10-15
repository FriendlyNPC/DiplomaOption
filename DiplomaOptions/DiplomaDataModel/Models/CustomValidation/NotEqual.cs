using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

public class NotEqual : ValidationAttribute
{
    private const string DefaultErrorMessage = "This option has already been selected";
    public List<string> BasePropertyName { get; private set; }
    private string errorCause;
    public NotEqual(string basePropertyName1, string basePropertyName2, string basePropertyName3 )
        : base(DefaultErrorMessage)
    {
        BasePropertyName = new List<string>();
        BasePropertyName.Add(basePropertyName1);
        BasePropertyName.Add(basePropertyName2);
        BasePropertyName.Add(basePropertyName3);
    }
    public override string FormatErrorMessage(string name)
    {
        return string.Format(DefaultErrorMessage);
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        foreach(string prop in BasePropertyName)
        {
            var property = validationContext.ObjectType.GetProperty(prop);
            if (property == null)
            {
                continue;
            }
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);
            if (object.Equals(value, otherValue))
            {

                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
        }
        return null;
    }
}