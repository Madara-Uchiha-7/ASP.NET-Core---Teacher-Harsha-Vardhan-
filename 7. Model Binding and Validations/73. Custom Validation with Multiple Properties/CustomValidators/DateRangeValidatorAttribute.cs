using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _73._Custom_Validation_with_Multiple_Properties.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName) 
        {
            OtherPropertyName = otherPropertyName;
        }


        override protected ValidationResult? IsValid (object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);

                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (otherProperty != null)
                {
                    DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                    // ObjectInstance which refers to the model object which is created by model binding.
                    // See, once the request is received, of course, first routing executes.
                    // Once the action method is detected based on the route, first model
                    // binding picks up all the values from various data sources from the request such as form data, route
                    // data, and query string parameters, etc. So once the model binding has
                    // been completed, it automatically creates a new object of the model class, right?
                    // So that model object is represented as ObjectInstance property here.
                    // Data type of this ObjectInstance is Object. So that is the reason you
                    // cannot get the actual property values directly. Actually, in our example, this
                    // ObjectInstance property refers to an object of the Person class, but directly you cannot read any of
                    // its properties Because by default, its data type is Object, that is System.Object class.
                    // But in C-sharp, there is a possibility of retrieving the values from the property dynamically, that is
                    // through reflection. It is a concept of reading the metadata from the objects and classes.
                    // So at runtime, you would like to read the value from the particular property.
                    // But before that, you have to get the reference to the property. So that is represented as 
                    // PropertyInFo which is present in using System.Reflection;
                    // .ObjectType will give you the reference of the type of the model class. Here type represents a class, that
                    // is Model class in this case.
                    // Reflection concept is helpful when you want to access the property values
                    // or invoke the methods indirectly from the objects which you are getting dynamically.
                    // Please debug this and check validationContext.

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[]
                        {
                            OtherPropertyName, validationContext.MemberName
                        });
                        // As a second argument, we can pass the property names dynamically.
                        // It will be helpful to display error messages near the corresponding
                        // text boxes. For example, if the FromDate and
                        // ToDate have errors, it will be very useful to display the error
                        // message near the corresponding text boxes.
                        // In case if we don't supply the name of the properties, then
                        // where this error message should be displayed?
                        // It's confusing, right? So it's better to pass the name of the properties which contains
                        // the error message.
                        // On Postsman same error related to this will be given 2 times because we are passing
                        // the 2 property names here.
                    }
                }
            }
            return null;
            // null means no validation result.
        }
    }
}
