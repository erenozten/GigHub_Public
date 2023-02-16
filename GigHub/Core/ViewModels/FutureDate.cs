using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Core.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        // bunun yerine client-side validation yapılabilir
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime);

            //CurrentCulture hata veriyor

            return (isValid && dateTime > DateTime.Now);
        }
    }
}