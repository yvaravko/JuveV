using System;
using System.Collections.Generic;

namespace DataAccess.Domain
{
    public class Player : BaseEntityWithId
    {
        public int PlayerTypeId { get; set; }

        public PlayerType PlayerType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int CurrentTeamId { get; set; }

        public Team CurrentTeam { get; set; }

        public int TeamNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Photo { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public string Note { get; set; }

        public IList<Team> PreviousTeams { get; set; }
    }
}