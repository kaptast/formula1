﻿using System;
using System.Collections.Generic;
using System.Text;

namespace kaptast_formula1_api.Repository.Entities
{
    public class Team : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfFoundation { get; set; }
        public int ChampionshipsWon { get; set; }
        public bool EntryPaid { get; set; }
    }
}
