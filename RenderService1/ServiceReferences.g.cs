﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Fabric;
using Microsoft.ApplicationServer.ApplicationModel;

namespace RenderService
{
    class ServiceReferences
    {

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudImagesReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudImagesReference");
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudImagesReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudImagesReference", null, contextProperties);
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudVideosReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudVideosReference");
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudBlobClient CreateCloudVideosReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudBlobClient>("CloudVideosReference", null, contextProperties);
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudTableClient CreateCloudObservationsTableReference()
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudTableClient>("CloudObservationsTableReference");
        }

        public static Microsoft.WindowsAzure.StorageClient.CloudTableClient CreateCloudObservationsTableReference(System.Collections.Generic.Dictionary<string, object> contextProperties)
        {
            return Service.ExecutingService.ResolveImport<Microsoft.WindowsAzure.StorageClient.CloudTableClient>("CloudObservationsTableReference", null, contextProperties);
        }
    }
}
