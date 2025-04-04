namespace CarRental3._0.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
