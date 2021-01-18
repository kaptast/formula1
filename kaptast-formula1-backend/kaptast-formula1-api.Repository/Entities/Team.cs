using KaptastFormula1Api.Repository.Entities.Interfaces;
using System;

namespace KaptastFormula1Api.Repository.Entities
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
