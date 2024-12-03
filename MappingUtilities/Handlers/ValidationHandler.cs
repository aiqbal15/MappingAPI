using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

namespace MappingUtilities.Handlers
{
    internal class ValidationHandler
    {
        internal static void ValidateInputData(object data, string sourceType, string targetType)
        {

            if (!DataModelHandler.Validate(sourceType))
            {
                throw new Exception("Source Type must be provided and should be within the defined types.");
            }

            if (!DataModelHandler.Validate(targetType))
            {
                throw new Exception("Target Type must be provided and should be within the defined types.");
            }
        
            if (data is null)
            {
                throw new Exception("Source Data must be provided.");
            }

            ValidateObject(data, DataModelHandler.GetType(sourceType));
        }

        public static void ValidateObject(object data, Type classType)
        {
            try
            {
                var obj = (JsonElement)data;
                var classProperties = classType.GetProperties();

                foreach (var propertyInfo in classProperties)
                {
                    JsonElement objProperty = new JsonElement();
                    try
                    {
                        objProperty = obj.GetProperty(propertyInfo.Name);
                    }
                    catch
                    {
                        throw new ArgumentException($"Data is missing the property '{propertyInfo.Name}'.");
                    }

                    if (!CompareJsonValueKindToPropertyType(objProperty, propertyInfo))
                    {
                        throw new ArgumentException($"Property '{propertyInfo.Name}' has an incorrect type. Expected '{propertyInfo.PropertyType}', but found '{objProperty.ValueKind}'.");
                    }
                }
            }
            catch
            {
                throw;
            }
            
        }

        public static bool CompareJsonValueKindToPropertyType(JsonElement jsonElement, PropertyInfo propertyInfo)
        {
            var jsonType = jsonElement.ValueKind;
            var propertyType = propertyInfo.PropertyType;
            string propertyTypeName = propertyInfo.PropertyType.Name;


            if (jsonType == JsonValueKind.Object)
            {
                if (!propertyType.IsClass || propertyType == typeof(string))
                {
                    return false;
                }

                var jsonProperties = jsonElement.EnumerateObject();
                var classProperties = propertyType.GetProperties();

                foreach (var jsonProp in jsonProperties)
                {
                    var matchingProperty = classProperties.FirstOrDefault(p => p.Name == jsonProp.Name);
                    if (matchingProperty == null)
                    {
                        return false;
                    }

                    if (!CompareJsonValueKindToPropertyType(jsonProp.Value, matchingProperty))
                    {
                        return false;
                    }
                }

                return true;
            }

            return jsonType switch
            {
                JsonValueKind.String => propertyType.Name == "String",
                JsonValueKind.Number => propertyType.Name == "Int32" || propertyType.Name == "Double" || propertyType.Name == "Decimal" || propertyType.Name == "Single",
                JsonValueKind.True or JsonValueKind.False => propertyType.Name == "Boolean",
                JsonValueKind.Null => !propertyType.IsValueType || Nullable.GetUnderlyingType(propertyType) != null,
                JsonValueKind.Array => HandleJsonArray(jsonElement, propertyType),
                _ => false
            };
        }

        private static bool HandleJsonArray(JsonElement jsonElement, Type propertyType)
        {
            if (propertyType.IsArray)
            {
                var elementType = propertyType.GetElementType();
                return MatchArrayElementType(jsonElement, elementType);
            }
            else if (typeof(IEnumerable<object>).IsAssignableFrom(propertyType) && propertyType.IsGenericType)
            {
                var genericArgument = propertyType.GetGenericArguments()[0];
                return MatchArrayElementType(jsonElement, genericArgument);
            }

            return false;
        }

        private static bool MatchArrayElementType(JsonElement jsonElement, Type elementType)
        {
            foreach (var item in jsonElement.EnumerateArray())
            {
                var itemType = item.ValueKind switch
                {
                    JsonValueKind.String => typeof(string),
                    JsonValueKind.Number => typeof(int),
                    JsonValueKind.True or JsonValueKind.False => typeof(bool),
                    JsonValueKind.Null => null,
                    JsonValueKind.Object => elementType.IsClass ? elementType : null,
                    _ => null
                };

                if (itemType != null && itemType != elementType)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
