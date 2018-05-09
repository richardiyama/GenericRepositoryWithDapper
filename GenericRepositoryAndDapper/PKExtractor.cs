

using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenericRepositoryAndDapper
{
    public class PKExtractor : IPKExtractor
    {
        public IEnumerable<object> ExtractPKInObjectEnumerable(object pk)
        {
            ParameterValidator.ValidateObject(pk, nameof(pk));

            var properties = pk.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(pk);

                if (value == null) throw new ArgumentNullException("Property of PK", $"The property {property.Name} can't be null");

                yield return value;
            }
        }
    }
}
