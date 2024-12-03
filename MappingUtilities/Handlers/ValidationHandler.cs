namespace MappingUtilities.Handlers
{
    internal class ValidationHandler
    {
        internal static void ValidateInputData(object data, string sourceType, string targetType)
        {

            if (!DataModelHandler.Validate(sourceType))
            {
                throw new Exception("Source Type is not within the defined types.");
            }

            if (!DataModelHandler.Validate(targetType))
            {
                throw new Exception("Target Type is not within the defined types.");
            }
        
            if (data is null)
            {
                throw new Exception("Source Data must be provided.");
            }
        }

        public static void ValidateObject(object obj, Type classType)
        {
            var objType = obj.GetType();
            var classProperties = classType.GetProperties();

            foreach (var propertyInfo in classProperties)
            {
                var objProperty = objType.GetProperty(propertyInfo.Name);

                if (objProperty == null)
                {
                    throw new ArgumentException($"Object is missing the property '{propertyInfo.Name}'.");
                }

                if (objProperty.PropertyType != propertyInfo.PropertyType)
                {
                    throw new ArgumentException($"Property '{propertyInfo.Name}' has an incorrect type. Expected '{propertyInfo.PropertyType}', but found '{objProperty.PropertyType}'.");
                }
            }
        }
    }
}
