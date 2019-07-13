using System.Diagnostics.Contracts;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

namespace NashTechAdsAPI.Services
{
    public class BlobStorageService : IStorageService
    {
        private CloudBlobContainer _blobContainer;
        private string _publicEndpoint;

        public BlobStorageService(IConfiguration configuration)
        {
            var storageConnectionString = configuration["AzureStorageAccount:ConnectionString"];
            var containerName = configuration["AzureStorageAccount:Blob:ContainerName"];
            _publicEndpoint = configuration["AzureStorageAccount:Blob:PublicEndpoint"];

            Contract.Requires(string.IsNullOrWhiteSpace(storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(containerName));

            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = blobClient.GetContainerReference(containerName);

            if (string.IsNullOrWhiteSpace(_publicEndpoint))
            {
                _publicEndpoint = _blobContainer.Uri.AbsoluteUri;
            }

        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.DeleteIfExistsAsync();
        }

        public string GetMediaUrl(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return "";
            }

            return $"{_publicEndpoint}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });
            await _blobContainer.CreateIfNotExistsAsync();

            var blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(mediaBinaryStream);
        }
    }
}
