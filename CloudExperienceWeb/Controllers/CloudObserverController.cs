using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CloudObserver;

namespace CloudExperienceWeb.Controllers
{
    public class CloudObserverController : Controller
    {
        public ActionResult Index()
        {
            //var context = new CloudObserverDB();
            //var observations = from at in context.Observations  select new  { City = at.City, CameraId = at.CameraId, Lat = at.Lat, Long = at.Long, ObservationTimeStamp = at.ObservationTimeStamp, ImageTimeStamp = at.ImageTimeStamp };
            //ViewBag.Observations = observations.ToList().Select(o => new CloudObservation { City = o.City, CameraId = o.CameraId, Lat = o.Lat, Long = o.Long,ObservationTimeStamp = o.ObservationTimeStamp, ImageTimeStamp = o.ImageTimeStamp });

            return View();
        }

        public ActionResult GridData(string sidx, string sord, int page, int rows)
        {
            //var context = new CloudObserverDB();
            //var observations = from at in context.Observations select new { City = at.City, CameraId = at.CameraId, Lat = at.Lat, Long = at.Long, ObservationTimeStamp = at.ObservationTimeStamp, ImageTimeStamp = at.ImageTimeStamp };
           // ViewBag.Observations = observations.ToList().Select(o => new CloudObservation { City = o.City, CameraId = o.CameraId, Lat = o.Lat, Long = o.Long, ObservationTimeStamp = o.ObservationTimeStamp, ImageTimeStamp = o.ImageTimeStamp });

            return View();
       
        }
    }
}
