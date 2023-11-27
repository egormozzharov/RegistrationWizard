namespace RegistrationWizard.Server.Services
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task CompleteAsync();
    }
}
