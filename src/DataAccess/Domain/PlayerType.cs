﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain
{
    public class PlayerType : BaseEntityWithId
    {
        public string Type { get; set; }
    }
}