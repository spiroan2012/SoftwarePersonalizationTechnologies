namespace Intefaces.Services
{
    public interface IEmailService
    {
        void SendEmail(string subject, string? recipient, string? messageBody);
    }
}
