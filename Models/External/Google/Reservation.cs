namespace DataModels.External.Google
{
    public class Reservation
    {
        public string? ID { get; set; }
        public string? HotelID { get; set; }
        public string? GuestID { get; set; }
        public string? RoomID { get; set; }
        public string? PaymentID { get; set; }
        public string? CheckInTS { get; set; }
        public string? CheckOutTS { get; set; }
        public int CheckInGuests { get; set; }
        public string? BookingDate { get; set; }
        public string? BookingStatus { get; set; }
        public string? AdditionalDetails { get; set; }
    }
}
