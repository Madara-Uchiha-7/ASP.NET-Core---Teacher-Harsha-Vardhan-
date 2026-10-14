using System.ComponentModel.DataAnnotations;

namespace _72._Custom_Validation.CustomValidators
{
    public class MinimumYearValidationAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";
        // To accept the custom data for custom Validator from the Attribute which we added above the property,
        // we need to define the parameterless and then parameterized constructor.
        public MinimumYearValidationAttribute() { }

        public MinimumYearValidationAttribute(int minimumYear) 
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateTime = (DateTime)value;
                if (dateTime.Year < MinimumYear)
                {
                    // return new ValidationResult("Birth Year can not be less than 2000");
                    // If we are using the ErrorMessage Property in our attribute above the property,
                    // then we have to use below line. If not then you can use above.
                    // return new ValidationResult(ErrorMessage);
                    // Since we are passing the MinimumYear from our attribute which is defined above the property,
                    // and we are using it in ErrorMessage as {0},
                    // we need to return as below:
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                    // If user does :
                    // [MinimumYearValidation(2005)]
                    // Instead of :
                    // [MinimumYearValidation(2005, ErrorMessage = "Date of birth should not be less than Jan 1,{0}")]
                    // That is, if he does not give ErrorMessage then Default one will be used which we have given on the top.
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
