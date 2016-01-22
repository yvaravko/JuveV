namespace DataAccess.Domain
{
    public class Tournament : BaseEntityWithId
    {
        public string Name { get; set; }

        public int SeasonId { get; set; }

        public Season Season { get; set; }
    }
}