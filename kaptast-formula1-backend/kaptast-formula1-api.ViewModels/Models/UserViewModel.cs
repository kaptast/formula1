using System;

namespace KaptastFormula1Api.ViewModels.Models
{
    /// <summary>
    /// Represent an user object. Used to communicate with the api
    /// </summary>
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
