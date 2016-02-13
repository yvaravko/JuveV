using System.Threading.Tasks;

namespace Infrustructure.Services.Account
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
