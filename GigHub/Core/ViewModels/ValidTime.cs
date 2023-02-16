using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Core.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        // girilen saat değeri valid mi. örnek bir valid saat: 22:15 
        // Bu validasyon client-side'da da yapılabilir, daha iyi olur
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "HH:mm", 
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, 
                out dateTime);

            return (isValid);
        }
    }
}