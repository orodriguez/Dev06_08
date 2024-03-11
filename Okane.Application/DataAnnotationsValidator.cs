using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Okane.Application
{
    public class DataAnnotationsValidator<T>
    {
        public IDictionary<string, string[]> Validate(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var results = new List<ValidationResult>();
            var context = new ValidationContext(
                obj, serviceProvider: null, items: null);

            Validator.TryValidateObject(obj, context, results, validateAllProperties: true);

            return results
                .GroupBy(result => string.Join('+', result.MemberNames))
                .ToDictionary(
                    grouping => grouping.Key, 
                    ToArray);
        }

        private static string[] ToArray(IGrouping<string, ValidationResult> grouping) => 
            grouping.Select(result => result.ErrorMessage ?? string.Empty).ToArray();
    }
}