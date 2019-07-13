using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Configuration;

namespace NashTechAdsAPI.Services
{
    public class StorageQueueService : IQueueService
    {
        private readonly CloudQueue _cloudQueue;

        public StorageQueueService(IConfiguration configuration)
        {
            var storageConnectionString = configuration["AzureStorageAccount:ConnectionString"];
            var queueName = configuration["AzureStorageAccount:QueueName"];

            Contract.Requires(string.IsNullOrWhiteSpace(storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(queueName));

            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            var queueClient = storageAccount.CreateCloudQueueClient();
            _cloudQueue = queueClient.GetQueueReference(queueName);
        }

        public async Task SendMessage(string message)
        {
            var cloudQueuMessage = new CloudQueueMessage(message);
            await _cloudQueue.AddMessageAsync(cloudQueuMessage);
        }
    }
}
