using System.Collections.Generic;
using TicTacToe.Model;

namespace TicTacToe.Data
{
    public interface IMatchRepository
    {
        List<Match> GetMatchHistory(int userId);
        void AddMatch(Match match);
    }
}