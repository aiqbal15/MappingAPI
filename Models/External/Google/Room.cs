namespace DataModels.External.Google
{
    public class Room
    {
        public string? ID { get; set; }
        public string? HotelID { get; set; }
        public string? Category { get; set; }
        public int NoOfBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public int NoOfKitchen { get; set; }
        public int Floor { get; set; }
        public int GuestLimit { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Area { get; set; }
        public string? AvailableFrom { get; set; }
        public string? Description { get; set; }
    }
}
