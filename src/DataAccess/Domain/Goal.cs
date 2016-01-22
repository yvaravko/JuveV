namespace DataAccess.Domain
{
    public class Goal : BaseEntityWithId
    {
        public int MatchId { get; set; }

        public Match Match { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int Minute { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }
    }
}