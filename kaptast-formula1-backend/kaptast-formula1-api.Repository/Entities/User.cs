using System;
using System.Collections.Generic;
using System.Text;

namespace kaptast_formula1_api.Repository.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
