using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using _77._Model_Binder_Providers.Models;

namespace _77._Model_Binder_Providers.CustomModelBinders
{
    public class PersonBinderProvider : IModelBinderProvider
    {
        // This GetBinder method will be executed automatically before the model binding process starts.
        // That means after routing then you have to check if the context.Metadata.ModelType equal to
        // type of person that means if the model object type is person type then you have
        // to specify that you would like to use the person model binder.
        // This ModelType property represents the type of the model class which has to be binded.
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
            {
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }
            return null;
        }
    }
}
