using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Fabric;
using Microsoft.ApplicationServer.ApplicationModel;

namespace SpotService
{
    class ServiceReferences
    {

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
