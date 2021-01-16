using System;

namespace kaptast_formula1_api.ViewModels.Models
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfFoundation { get; set; }
        public int ChampionshipsWon { get; set; }
        public bool EntryPaid { get; set; }
    }
}
