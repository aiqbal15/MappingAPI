using System.Security.AccessControl;
using Utilities.Mappers;

namespace Utilities.Handlers
{
    public class MapHandler
    {
        public object Map(object data, string sourceTypeName, string targetTypeName)
        {
            try
            {
                #region Step - 1: Validate data, source and target types
                ValidationHandler.ValidateInputData(data, sourceTypeName, targetTypeName);
                #endregion


                #region Step - 2: Map data to source
                Type sourceType = DataModelHandler.GetType(sourceTypeName);
                var sourceObj = DataModelHandler.GetObject(sourceTypeName);
                
                var _sourceObj = DataModelHandler.GetSourceObject(data, sourceType);
                if (_sourceObj != null)
                {
                    sourceObj = Convert.ChangeType(_sourceObj, sourceType);
                }
                #endregion


                #region Step - 3: Map source to target
                var targetObj = DataModelHandler.GetObject(targetTypeName);
                MapSourceToData(sourceObj, ref targetObj);
                #endregion


                return targetObj;
            }
            catch 
            {
                throw;
            }
        }

        private void MapSourceToData(Object sourceObj, ref Object targetObj) 
        {
            // Step - 1: Get the appropriate IMapper instance
            var mapperInstance = MapperFactory.GetMapperInstance(sourceObj.GetType(), targetObj.GetType());

            //Step - 2: Map source to target
            if (mapperInstance != null) 
            {
                var mapperType = mapperInstance.GetType();

                var mapMethod = mapperType.GetMethod("Map");

                if (mapMethod != null)
                {
                    var parameters = new object[] { sourceObj, targetObj };
                    mapMethod.Invoke(mapperInstance, parameters);

                    targetObj = parameters[1];
                }
            }            
        }
    }
}
