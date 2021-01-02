namespace Data.Models
{
    public sealed class Dealership
    {
        public string Name { get; set; }

        public string Address1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string[] Cars { get; set; }
    }
}
