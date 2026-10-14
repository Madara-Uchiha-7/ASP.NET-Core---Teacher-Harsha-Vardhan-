using _77._Model_Binder_Providers.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _77._Model_Binder_Providers.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();

            // It is possible that we get more then 1 FirstName, (for now from postman)
            // i.e. more than 1 FirstName key.
            // So below line may return more than 1 result.
            ValueProviderResult firstName = bindingContext.ValueProvider.GetValue("FirstName");
            if (firstName.Length > 0)
            {
                string startingName = firstName.FirstValue!; // We are trying to get only the first value among multiple.

                ValueProviderResult lastName = bindingContext.ValueProvider.GetValue("LastName");
                if (lastName.Length > 0)
                {
                    person.Name =  string.Format($"{firstName} {lastName.FirstValue}");
                }
            }
            bindingContext.Result = ModelBindingResult.Success(person);
            // So, the Person object which you are supplying here as argument,
            // that will be received into this model parameter in this action method.
            // So, in other words, as soon as the request is received and a route is selected,
            // this model binding process executes and the model object that is returned from here
            // will be available in the Controller class action method parameter.
            // 
            return Task.CompletedTask;

            // As a part of the model binding,
            // you need not care about model validation
            // since we have already added the model binding related attributes
            // and custom validators earlier. So, that validations will work as it is.
        }
    }
}
