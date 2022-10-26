using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TicTacToe.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}
