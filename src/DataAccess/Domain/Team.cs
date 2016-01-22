namespace DataAccess.Domain
{
    public class Team : BaseEntityWithId
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}