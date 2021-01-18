using System;

namespace KaptastFormula1Api.ViewModels.Models
{
    /// <summary>
    /// Represent a Team object. Used to communicate with the api
    /// </summary>
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfFoundation { get; set; }
        public int ChampionshipsWon { get; set; }
        public bool EntryPaid { get; set; }
    }
}
