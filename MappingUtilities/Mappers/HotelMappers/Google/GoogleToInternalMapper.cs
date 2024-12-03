using SourceModel = DataModels.External.Google.Hotel;
using TargetModel = DataModels.Internal.Hotel;

namespace MappingUtilities.Mappers.HotelMappers.Google
{
    public class GoogleToInternalMapper : IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.HotelID = sourceModel.ID;
                targetModel.HotelName = sourceModel.Name;
                targetModel.HotelDescription = sourceModel.Description;
                targetModel.Location = new DataModels.Internal.Location();

                if (sourceModel.Location != null)
                {
                    var location = new DataModels.Internal.Location();
                    new LocationMappers.Google.GoogleToInternalMapper().Map(sourceModel.Location, ref location);
                    targetModel.Location = location;
                }

            }
        }
    }
}
