using Habanero.Util;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace OnlineShop.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result =
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (result != ValueProviderResult.None && string.IsNullOrEmpty(result.FirstValue))
            {
                decimal actualValue = 0m;
                bool success = false;

                try
                {
                    string decValue = result.FirstValue;

                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                     
                    actualValue=Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);
                    success = true;
                    
                }



                catch (FormatException fe )
                {

                    bindingContext.ModelState.AddModelError(bindingContext.ModelName,fe, bindingContext.ModelMetadata);
                }
                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }

            }
                return Task.CompletedTask;

        }
    }
}
