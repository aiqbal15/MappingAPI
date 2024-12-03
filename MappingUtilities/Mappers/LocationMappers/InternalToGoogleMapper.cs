using SourceModel = DataModels.Internal.Location;
using TargetModel = DataModels.External.Google.Location;

namespace MappingUtilities.Mappers.LocationMappers.Google
{
    public class InternalToGoogleMapper:IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.City = sourceModel.City;
                targetModel.Country = sourceModel.Country;
                targetModel.PostalCode = sourceModel.ZipCode;
            }
        }
    }
}
