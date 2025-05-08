namespace Raja_Country_Api.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public Country Country { get; set; }
        public ICollection<District> Districts { get; set; }
    }
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateName { get; set; }
        public State State { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }
}


