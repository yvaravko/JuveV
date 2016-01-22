namespace DataAccess.Domain
{
    public class Video : BaseEntityWithId
    {
        //TODO: change type to blob compatible
        public string VideoExerpt { get; set; }
    }
}