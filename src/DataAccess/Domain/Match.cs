namespace DataAccess.Domain
{
    public class Match : BaseEntityWithId
    {
        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int GuestTeamId { get; set; }

        public Team GuestTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }
    }
}