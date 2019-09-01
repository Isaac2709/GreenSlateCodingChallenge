using System;
using System.Collections.Generic;

namespace GS.CodingChallenge.Domain.Models
{
    public partial class Project
    {
        public Project()
        {
            UserProject = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }

        public ICollection<UserProject> UserProject { get; set; }
    }
}
