namespace DataModels.Internal
{
    public class Reservation
    {
        public string? ReservationID { get; set; }
        public string? HotelID { get; set; }
        public string? GuestID { get; set; }
        public string? RoomID { get; set; }
        public string? PaymentID { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        public int NoOfGuests {  get; set; }
        public string? BookingDate { get; set; }
        public string? Status {  get; set; }
        public string? AdditionalDetails {  get; set; }
    }
}
