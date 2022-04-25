using DRApplication.Shared.Models.SMTPModels;

namespace DRApplication.Server.Services
{
    public interface ISmtpEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
