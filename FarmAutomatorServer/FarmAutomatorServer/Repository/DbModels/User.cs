using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmAutomatorServer.Repository.DbModels
{
    public class User
    {
        public int UserId { get; set; }

        public string LoginId { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
