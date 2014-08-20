using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Fabric;
using Microsoft.ApplicationServer.ApplicationModel;

namespace CloudExperienceWeb
{
    class ServiceReferences
    {

        public static Microsoft.WindowsAzure.StorageClient.CloudTableClient CreateObservationsTableReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudTableClient>("ObservationsTableReference");
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudTableClient CreateObservationsTableReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudTableClient>("ObservationsTableReference", null, contextProperties);
        }

        public static Microsoft.ServiceBus.Messaging.QueueClient CreateRenderQueueReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.ServiceBus.Messaging.QueueClient>("RenderQueueReference");
        }

        public static Microsoft.ServiceBus.Messaging.QueueClient CreateRenderQueueReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.ServiceBus.Messaging.QueueClient>("RenderQueueReference", null, contextProperties);
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudVideosReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudVideosReference");
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudVideosReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudVideosReference", null, contextProperties);
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudImagesReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudImagesReference");
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudImagesReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudImagesReference", null, contextProperties);
        }
    }
}
