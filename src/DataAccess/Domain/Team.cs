namespace DataAccess.Domain
{
    public class Team : BaseEntityWithId
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}