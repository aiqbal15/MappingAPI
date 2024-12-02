using SourceModel = DataModels.Internal.Room;
using TargetModel = DataModels.External.Google.Room;

namespace Utilities.Mappers.RoomMappers.Google
{
    public class InternalToGoogleMapper:IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.ID = sourceModel.ID;
                targetModel.HotelID = sourceModel.HotelID;
                targetModel.Category = sourceModel.Category;
                targetModel.NoOfBedrooms = sourceModel.Bedrooms;
                targetModel.NoOfBathrooms = sourceModel.Bathrooms;
                targetModel.NoOfKitchen = sourceModel.Kitchen;
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
