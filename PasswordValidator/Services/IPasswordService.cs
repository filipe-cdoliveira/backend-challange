namespace PasswordValidator.Services
{
    public interface IPasswordService
    {
        bool IsValid(string password);
    }
}
