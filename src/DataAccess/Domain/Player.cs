using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Domain
{
    public class Player : BaseEntityWithId
    {
        public int PlayerTypeId { get; set; }

        public virtual PlayerType PlayerType { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int CurrentTeamId { get; set; }

        public virtual Team CurrentTeam { get; set; }

        public int TeamNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Photo { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string Note { get; set; }

        //public IList<Team> PreviousTeams { get; set; }
    }
}