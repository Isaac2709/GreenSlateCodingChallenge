using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.CodingChallenge.WebApplication.Models
{
    public class UserProjectViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
