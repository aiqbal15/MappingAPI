using SourceModel = DataModels.External.Google.Room;
using TargetModel = DataModels.Internal.Room;

namespace MappingUtilities.Mappers.RoomMappers.Google
{
    public class GoogleToInternalMapper : IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.ID = sourceModel.ID;
                targetModel.HotelID = sourceModel.HotelID;
                targetModel.Category = sourceModel.Category;
                targetModel.Bedrooms = sourceModel.NoOfBedrooms;
                targetModel.Bathrooms = sourceModel.NoOfBathrooms;
                targetModel.Kitchen = sourceModel.NoOfKitchen;
                targetModel.Floor = sourceModel.Floor;
                targetModel.GuestLimit = sourceModel.GuestLimit;
                targetModel.Price = sourceModel.Price;
                targetModel.IsAvailable = sourceModel.IsAvailable;
                targetModel.Area = sourceModel.Area;
                targetModel.AvailableFrom = sourceModel.AvailableFrom;
                targetModel.Description = sourceModel.Description;
            }
        }
    }
}
