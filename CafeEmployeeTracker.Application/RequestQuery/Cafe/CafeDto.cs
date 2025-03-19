namespace CafeEmployeeTracker.Application.RequestQuery.Cafe
{
    public class CafeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }
        public int EmployeeCount { get; internal set; }

        public CafeDto() { }
        public CafeDto(Guid id, string name, string description, string logo, string location)
        {
            Id = id;
            Name = name;
            Description = description;
            Logo = logo;
            Location = location;
         
        }
    }
}