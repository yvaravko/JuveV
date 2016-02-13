using System.Threading.Tasks;

namespace Infrustructure.Services.Account
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
