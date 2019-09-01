using System;
using System.Collections.Generic;

namespace GS.CodingChallenge.Domain.Models
{
    public partial class UserProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        public DateTime AssignedDate { get; set; }

        public Project Project { get; set; }
        public User User { get; set; }
    }
}
