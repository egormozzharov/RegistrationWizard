using RegistrationWizard.Server.Models;

namespace RegistrationWizard.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SaveUserAsync(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _unitOfWork.UserRepository.GetByEmailAsync(email);
        }
    }
}