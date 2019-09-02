using GS.CodingChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.CodingChallenge.Application.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(GSCodeChallengeContext context) : base(context)
        {
        }
    }
}
