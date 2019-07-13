using System.Threading.Tasks;

namespace NashTechAdsAPI.Services
{
    public interface IQueueService
    {
        Task SendMessage(string message);
    }
}
