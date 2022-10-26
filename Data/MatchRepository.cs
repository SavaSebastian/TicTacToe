using System.Collections.Generic;
using TicTacToe.Model;
using System.Linq;

namespace TicTacToe.Data
{
    public class MatchRepository : IMatchRepository
    {
        private readonly UserDbContext _context;

        public MatchRepository(UserDbContext context)
        {
            _context = context;
        }

        public List<Match> GetMatchHistory(int userId)
        {
            return (from match in _context.Matches 
                where match.UserId == userId
                select match)
                .ToList();
        }

        public void AddMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }
    }
}