namespace DataModels.Internal
{
    public class Room
    {
        public string? ID { get; set; }
        public string? HotelID { get; set; }
        public string? Category { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Kitchen { get; set; }
        public int Floor { get; set; }
        public int GuestLimit { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Area { get; set; }
        public string? AvailableFrom { get; set; }
        public string? Description { get; set; }

    }
}
