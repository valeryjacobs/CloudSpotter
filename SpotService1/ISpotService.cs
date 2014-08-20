using System;
using System.ServiceModel;

namespace SpotService
{
    [ServiceContract(Namespace = "http://www.cloudcompanion.nl")]
    public interface ISpotService
    {
        [OperationContract]
        void Spot(string query);
    }
}
