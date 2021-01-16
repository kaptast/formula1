using kaptast_formula1_api.Repository.Entities.Interfaces;
using System;

namespace kaptast_formula1_api.Repository.Entities
{
    public class Team : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfFoundation { get; set; }
        public int ChampionshipsWon { get; set; }
        public bool EntryPaid { get; set; }
    }
}
