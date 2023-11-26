using System.Threading.Tasks;
using RegistrationWizard.Server.Models;

namespace RegistrationWizard.Server.Services
{
    public interface IUserService
    {
        Task SaveUserAsync(User user);
        Task<User> GetUserAsync(string email);
    }
}
