using RegistrationWizard.Server.Models;

namespace RegistrationWizard.Server.Services
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
