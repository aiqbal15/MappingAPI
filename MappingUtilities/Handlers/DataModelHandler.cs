using System.ComponentModel;
using System.Text.Json;
using MappingUtilities.Extensions;

namespace MappingUtilities.Handlers
{
    internal static class DataModelHandler
    {
        public enum DataModelsEnum
        {
            [Description("google.hotel")]
            GOOGLE_HOTEL,

            [Description("google.location")]
            GOOGLE_LOCATION,

            [Description("google.reservation")]
            GOOGLE_RESERVATION,

            [Description("google.room")]
            GOOGLE_ROOM,

            [Description("internal.hotel")]
            INTERNAL_HOTEL,

            [Description("internal.location")]
            INTERNAL_LOCATION,

            [Description("internal.reservation")]
            INTERNAL_RESERVATION,

            [Description("internal.room")]
            INTERNAL_ROOM,
        }

        public static List<String> GetModelDescriptions()
        {
            try
            {
                List<String> descriptions = new List<String>();
                foreach (int item in Enum.GetValues(typeof(DataModelsEnum)))
                {
                    descriptions.Add((EnumExtensions.GetDescription((DataModelsEnum) item)).ToLower());
                }

                return descriptions;
            }
            catch
            {
                return new List<String>();
            }
        }

        public static bool Validate(string _type)
        {
            if (string.IsNullOrWhiteSpace(_type))
            {
                return false;
            }

            return GetModelDescriptions().Contains(_type.ToLower());
        }

        public static Type GetType(string typeName)
        {
            switch (typeName.ToLower())
            {
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.GOOGLE_HOTEL):
                    {
                        return typeof(DataModels.External.Google.Hotel);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.GOOGLE_LOCATION):
                    {
                        return typeof(DataModels.External.Google.Location);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.GOOGLE_RESERVATION):
                    {
                        return typeof(DataModels.External.Google.Reservation);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.GOOGLE_ROOM):
                    {
                        return typeof(DataModels.External.Google.Room);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.INTERNAL_HOTEL):
                    {
                        return typeof(DataModels.Internal.Hotel);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.INTERNAL_LOCATION):
                    {
                        return typeof(DataModels.Internal.Location);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.INTERNAL_RESERVATION):
                    {
                        return typeof(DataModels.Internal.Reservation);
                    }
                case var item when item == EnumExtensions.GetDescription((DataModelsEnum)DataModelsEnum.INTERNAL_ROOM):
                    {
                        return typeof(DataModels.Internal.Room);
                    }
                default:
                    {
                        return typeof(object);
                    }

            }
        }

        public static Object GetObject(string typeName)
        {
            try
            {
                return Activator.CreateInstance(GetType(typeName));
            }
            catch
            {
                throw new Exception($"Unable to get {typeName} object.");
            }
        }

        public static object GetSourceObject(object data, Type sourceType)
        {
            try
            {          
                var sourceObj = JsonSerializer.Deserialize((JsonElement)data, sourceType, JsonSerializerOptions.Default);
                
                if (sourceObj != null)
                {
                    return sourceObj;
                }
                else
                {
                    throw new InvalidCastException($"Cannot convert provided data to {sourceType.FullName}.");
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
