using Microsoft.Data.Entity.Metadata.Internal;

namespace DataAccess.Domain
{
    public class Team : BaseEntityWithId
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}