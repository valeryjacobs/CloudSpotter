using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Xml;
using System.Text;

namespace CloudExperienceWeb.Controllers
{
    public class CloudSpotterController : Controller
    {
        //
        // GET: /CloudSpotter/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Spot(string query,int noCams = 40)
        {
            string url = "http://api.wunderground.com/auto/wui/geo/GeoLookupXML/index.xml?query="+ query;

            // Create an interface to the web
            WebClient c = new WebClient();
            // Download the XML into a string
            string xml = ASCIIEncoding.Default.GetString(c.DownloadData(url));
            // Document to contain the feed
            XmlDocument doc = new XmlDocument();
            // Parse the xml
            doc.LoadXml(xml);

            string cams = string.Empty;
            // Display each cam
            List<Tuple<string,string>> camList = new List<Tuple<string,string>>();
            foreach (XmlNode node in doc.SelectNodes("/location/webcams/cam"))
            {
                string location = node.SelectSingleNode("city").InnerText;
                string imgUrl = node.SelectSingleNode("CURRENTIMAGEURL").InnerText;


                camList.Add(new Tuple<string, string>(imgUrl,location));

                if (camList.Count >= noCams) break;
            }

            ViewBag.Message = camList.Count.ToString() + " cams spotted";
            ViewBag.URLs = camList;

            return View();
        }
    }
}
