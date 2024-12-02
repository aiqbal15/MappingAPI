using SourceModel = DataModels.Internal.Reservation;
using TargetModel = DataModels.External.Google.Reservation;

namespace Utilities.Mappers.ReservationMappers.Google
{
    public class InternalToGoogleMapper:IMapper<SourceModel, TargetModel>
    {
        public void Map(SourceModel sourceModel, ref TargetModel targetModel)
        {
            targetModel = new TargetModel();
            if (sourceModel != null)
            {
                targetModel.ID = sourceModel.ReservationID;
                targetModel.HotelID = sourceModel.HotelID;
                targetModel.GuestID = sourceModel.GuestID;
                targetModel.RoomID = sourceModel.RoomID;
                targetModel.PaymentID = sourceModel.PaymentID;
                targetModel.CheckInTS = sourceModel.CheckIn;
                targetModel.CheckOutTS = sourceModel.CheckOut;
                targetModel.checkInGuests = sourceModel.NoOfGuests;
                targetModel.BookingDate = sourceModel.BookingDate;
                targetModel.BookingStatus = sourceModel.Status;
                targetModel.AdditionalDetails = sourceModel.AdditionalDetails;
            }
        }
    }
}
