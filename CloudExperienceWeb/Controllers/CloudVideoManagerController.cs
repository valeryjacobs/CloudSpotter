using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
//using CloudVideoRenderer;
//using CloudObserver;

namespace CloudExperienceWeb.Controllers
{
    public class CloudVideoManagerController : Controller
    {
        //
        // GET: /CloudVideoManager/

        public ActionResult Index()
        {
            List<string> frameRates = new List<string>();
            frameRates.Add("10");
            frameRates.Add("15");
            frameRates.Add("20");
            frameRates.Add("25");
            frameRates.Add("30");

            ViewData["frameRate"] = new SelectList(frameRates);

            ////var context = new CloudObserverDB();


            //var cameraIds = (from p in context.Observations
            //                 select p.CameraId).Distinct();

            //List<string> cameraIdList = new List<string>();

            //foreach (string s in cameraIds)
            //{
            //    cameraIdList.Add(s);
            //}

            //ViewData["cameraIdList"] = new SelectList(cameraIdList);


            //Video links:
            CloudBlobClient blobClient = new CloudBlobClient("http://cloudexperience.blob.core.windows.net/", new StorageCredentialsAccountAndKey("cloudexperience", "2gXf57tBwJq7MRTi9WkcPuTNdz66Ra7hD4BNIDGpv/ztlT+juvw2886rL8CYmWwRFwQUhNOBVAU67Rea3Cpnaw=="));
            //Get a reference to a container, which may or may not exist.
            CloudBlobContainer container = blobClient.GetContainerReference("cloudvideo");

            List<string> videoList = new List<string>();

            IEnumerable<IListBlobItem> blobList = container.ListBlobs();
            foreach (IListBlobItem item in blobList)
            {
                videoList.Add(item.Uri.AbsoluteUri.ToString());
            }

            ViewBag.VideoList = new SelectList(videoList);

            return View();
        }

        public ActionResult HandleForm(string cameraIdList, string frameRate, bool renderAll, string pass)
        {
            string response = string.Empty;
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cloudexperience;AccountKey=2gXf57tBwJq7MRTi9WkcPuTNdz66Ra7hD4BNIDGpv/ztlT+juvw2886rL8CYmWwRFwQUhNOBVAU67Rea3Cpnaw==");
            CloudQueueClient queueClient = account.CreateCloudQueueClient();
            CloudQueue renderJobQueue = queueClient.GetQueueReference("renderjobqueue");

            if (!renderJobQueue.Exists())
            {
                renderJobQueue.Create();
            }

            if (renderAll && pass == "cexp")
            {
                //var context = new CloudObserverDB();
                //var cameraIds = (from p in context.Observations
                //                 select p.CameraId).Distinct();


                //foreach (string s in cameraIds)
                //{
                //    CloudVideoRenderJob job = new CloudVideoRenderJob { CameraID = s, CloudVideoRenderJobId = Guid.NewGuid().ToString(), FrameRate = int.Parse(frameRate) };
                //    CloudQueueMessage message = new CloudQueueMessage(MessageSerializer.Serialize(job));
                //    renderJobQueue.AddMessage(message);

                //    response += job.CameraID + " - ";
                //}
            }
            else
            {
                //CloudVideoRenderJob job = new CloudVideoRenderJob { CameraID = cameraIdList, CloudVideoRenderJobId = Guid.NewGuid().ToString(), FrameRate = int.Parse(frameRate) };
                //CloudQueueMessage message = new CloudQueueMessage(MessageSerializer.Serialize(job));
                //renderJobQueue.AddMessage(message);

                //response = job.CameraID;
            }


            ViewBag.JobId = response;

            return View();
        }

    }
}
