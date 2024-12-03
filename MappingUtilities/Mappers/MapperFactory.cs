using System.Reflection;

namespace MappingUtilities.Mappers
{
    public static class MapperFactory
    {
        public static object GetMapperInstance(Type sourceModelType, Type targetModelType)
        {
            var mapperType = FindMapper(sourceModelType, targetModelType);

            if (mapperType == null)
            {
                throw new InvalidOperationException($"No mapper found for source type {sourceModelType.FullName} and target type {targetModelType.FullName}");
            }

            var mapperInstance = Activator.CreateInstance(mapperType);

            return mapperInstance;
        }

        private static Type FindMapper(Type sourceType, Type targetType)
        {
            
            var mapperType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    typeof(IMapper<,>).MakeGenericType(sourceType, targetType).IsAssignableFrom(t));

            return mapperType;
        }
    }
}
