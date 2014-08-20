using System;
using System.ServiceModel;
using System.Text;

namespace RenderService
{
    [ServiceContract(Namespace = "http://www.cloudcompanion.nl")]
    public interface IRenderService
    {
        [OperationContract]
        void Render(string cameraId);
    }
}
