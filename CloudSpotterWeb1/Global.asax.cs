using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.ApplicationServer.Web.Hosting;

namespace CloudSpotterWeb
{
    public class Global : System.Web.HttpApplication
    {
        public override void Init()
        {
            base.Init();

            WebApplicationHost.Initialize(this);
        }

        void Application_Start(object sender, EventArgs e)
        {
            WebApplicationHost.Start(this);
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            WebApplicationHost.Stop(this);
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
