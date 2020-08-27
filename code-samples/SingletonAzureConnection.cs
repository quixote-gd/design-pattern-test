using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SemsNet.Classes.AzureRepository
{
    public class SingletonAzureConnection
    {
        private static volatile SingletonAzureConnection _repo;
        private static object syncRoot = new Object();
        public BlobServiceClient ServiceClient { get; private set;}
        private SingletonAzureConnection()
        {
            ServiceClient = new BlobServiceClient(ConfigurationManager.ConnectionStrings["AzureBlobConnection"].ConnectionString);
        }
        public static SingletonAzureConnection Instance
        {
            get
            {
                if (_repo == null)
                {
                    // Prevent simultaneous access by multiple threads via the SyncRoot Pattern.
                    lock (syncRoot)
                    {
                        if (_repo == null)
                            _repo = new AzureBlobStorageConnection();
                    }
                }
                return _repo;
            }
        }
    }
}