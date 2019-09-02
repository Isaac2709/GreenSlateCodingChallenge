using GS.CodingChallenge.Domain.Models;

namespace GS.CodingChallenge.Application.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(GSCodeChallengeContext context) : base(context)
        {
        }
    }
}
