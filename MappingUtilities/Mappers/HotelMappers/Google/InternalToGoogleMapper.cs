using SourceModel = DataModels.Internal.Hotel;
using TargetModel = DataModels.External.Google.Hotel;

namespace MappingUtilities.Mappers.HotelMappers.Google
{
    public class InternalToGoogleMapper:IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.ID = sourceModel.HotelID;
                targetModel.Name = sourceModel.HotelName;
                targetModel.Description = sourceModel.HotelDescription;
                targetModel.Location = new DataModels.External.Google.Location();

                if (sourceModel.Location != null)
                {
                    var location = new DataModels.External.Google.Location();
                    new LocationMappers.Google.InternalToGoogleMapper().Map(sourceModel.Location, ref location);
                    targetModel.Location = location;
                }
            }
        }
    }
}
