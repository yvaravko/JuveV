namespace DataAccess.Domain
{
    public class PlayerReward
    {
        public Player Player { get; set; }

        public int PlayerId { get; set; }

        public int RewardId { get; set; }

        public Reward Reward { get; set; }

        public int Year { get; set; }
    }
}