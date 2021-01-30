namespace API.Interfaces
{
    public interface IEmailService
    {
        void Send(string subject, string message);
    }
}