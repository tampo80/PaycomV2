using System;

namespace PayCom.Blazor.Client.Pages.Contribuables.Models
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Ensures that a DateTime? value is not null, default, or invalid for API calls.
        /// Returns current date if the value is null, default, or invalid.
        /// </summary>
        public static DateTime EnsureValidDate(this DateTime? dateTime)
        {
            if (!dateTime.HasValue || 
                dateTime.Value == default || 
                dateTime.Value.Year <= 1900 || 
                dateTime.Value > DateTime.Now)
            {
                return DateTime.Now;
            }
            
            return dateTime.Value;
        }
        
        /// <summary>
        /// Ensures that a DateTime value is not default or invalid for API calls.
        /// Returns current date if the value is default or invalid.
        /// </summary>
        public static DateTime EnsureValidDate(this DateTime dateTime)
        {
            if (dateTime == default || 
                dateTime.Year <= 1900 || 
                dateTime > DateTime.Now)
            {
                return DateTime.Now;
            }
            
            return dateTime;
        }
    }
} 
