using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace FileUploader.Models
{
    public class BlobStorage : IStorage
    {
        private readonly AzureStorageConfig storageConfig;

        public BlobStorage(IOptions<AzureStorageConfig> storageConfig)
        {
            this.storageConfig = storageConfig.Value;
        }

        public Task Initialize()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConfig.ConnectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(storageConfig.FileContainerName);

            return blobContainerClient.CreateIfNotExistsAsync();
        }

        public Task Save(Stream fileStream, string name)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConfig.ConnectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(storageConfig.FileContainerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(name);

            return blobClient.UploadAsync(fileStream);
        }

        public async Task<IEnumerable<string>> GetNames()
        {
            List<string> names = new List<string>();

            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConfig.ConnectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(storageConfig.FileContainerName);

            await foreach (BlobItem blob in blobContainerClient.GetBlobsAsync(BlobTraits.None, BlobStates.None, string.Empty))
            {
                names.Add(blob.Name);
            }

            return names;
        }

        public async Task<Stream> Load(string name)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConfig.ConnectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(storageConfig.FileContainerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(name);
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            MemoryStream stream = new MemoryStream();
            await download.Content.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}