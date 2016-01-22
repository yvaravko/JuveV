namespace DataAccess.Domain
{
    public class TournamentTeam : BaseEntityWithId
    {
        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int Scores { get; set; }

        public int Missed { get; set; }
    }
}