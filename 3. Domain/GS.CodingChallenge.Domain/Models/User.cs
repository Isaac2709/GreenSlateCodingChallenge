using System;
using System.Collections.Generic;

namespace GS.CodingChallenge.Domain.Models
{
    public partial class User
    {
        public User()
        {
            UserProject = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserProject> UserProject { get; set; }
    }
}
