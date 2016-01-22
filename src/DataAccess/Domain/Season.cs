namespace DataAccess.Domain
{
    public class Season : BaseEntityWithId
    {
        public string Name { get; set; }
        public int StartYear { get; set; }
    }
}