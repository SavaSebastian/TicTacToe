using TicTacToe.Model;

namespace TicTacToe.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
        void DeleteUser(User user);
        User UpdateUserPassword(User user);
    }
}