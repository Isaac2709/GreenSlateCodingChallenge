using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GS.CodingChallenge.WebApplication.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        public int TimeToStart
        {
            get
            {
                var timeToDate = 0;
                if (UserProject.Count > 0)
                {
                    timeToDate = Convert.ToInt32((this.StartDate - UserProject.ElementAt(0).AssignedDate).TotalDays);
                }
                return timeToDate;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        public int Credits { get; set; }

        public string Status
        {
            get
            {
                var status = "Inactive";
                if (UserProject.Count > 0)
                {
                    status = UserProject.ElementAt(0).IsActive ? "Active" : "Inactive";
                }
                return status;
            }
        }

        public ICollection<UserProjectViewModel> UserProject { get; set; }
    }
}
