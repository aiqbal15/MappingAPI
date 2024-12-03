using SourceModel = DataModels.External.Google.Reservation;
using TargetModel = DataModels.Internal.Reservation;

namespace MappingUtilities.Mappers.ReservationMappers.Google
{
    public class GoogleToInternalMapper : IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.ReservationID = sourceModel.ID;
                targetModel.HotelID = sourceModel.HotelID;
                targetModel.GuestID = sourceModel.GuestID;
                targetModel.RoomID = sourceModel.RoomID;
                targetModel.PaymentID = sourceModel.PaymentID;
                targetModel.CheckIn = sourceModel.CheckInTS;
                targetModel.CheckOut = sourceModel.CheckOutTS;
                targetModel.NoOfGuests = sourceModel.checkInGuests;
                targetModel.BookingDate = sourceModel.BookingDate;
                targetModel.Status = sourceModel.BookingStatus;
                targetModel.AdditionalDetails = sourceModel.AdditionalDetails;
            }
        }
    }
}
