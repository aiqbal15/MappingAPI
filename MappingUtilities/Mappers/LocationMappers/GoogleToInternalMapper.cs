using SourceModel = DataModels.External.Google.Location;
using TargetModel = DataModels.Internal.Location;

namespace MappingUtilities.Mappers.LocationMappers.Google
{
    public class GoogleToInternalMapper : IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.City = sourceModel.City;
                targetModel.Country = sourceModel.Country;
                targetModel.ZipCode = sourceModel.PostalCode;                
            }
        }
    }
}
