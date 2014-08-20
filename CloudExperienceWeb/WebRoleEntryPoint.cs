using System;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole1
{
    public class WebRole : RoleEntryPoint
    {
        private readonly string wadConnectionString = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString";

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            System.Diagnostics.Trace.Listeners.Add(new Microsoft.WindowsAzure.Diagnostics.DiagnosticMonitorTraceListener());
            System.Diagnostics.Trace.TraceInformation("In OnStart");

            this.ConfigureDiagnosticMonitor();

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            RoleEnvironment.Changing += RoleEnvironmentChanging;

            return base.OnStart();
        }

        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            // If a configuration setting is changing
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
            {
                // Set e.Cancel to true to restart this role instance
                e.Cancel = true;
            }
        }

        /// <summary> 
        /// Performs initial configurarion for Windows Azure Diagnostics for the instance.
        /// </summary> 
        private void ConfigureDiagnosticMonitor()
        {
            DiagnosticMonitorConfiguration diagnosticMonitorConfiguration = DiagnosticMonitor.GetDefaultInitialConfiguration();

            diagnosticMonitorConfiguration.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1d);
            diagnosticMonitorConfiguration.Directories.BufferQuotaInMB = 100;

            diagnosticMonitorConfiguration.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1d);
            diagnosticMonitorConfiguration.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose;

            diagnosticMonitorConfiguration.WindowsEventLog.DataSources.Add("Application!*");
            diagnosticMonitorConfiguration.WindowsEventLog.DataSources.Add("System!*");
            diagnosticMonitorConfiguration.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1d);

            PerformanceCounterConfiguration performanceCounterConfiguration = new PerformanceCounterConfiguration();
            performanceCounterConfiguration.CounterSpecifier = @"\Processor(_Total)\% Processor Time";
            performanceCounterConfiguration.SampleRate = System.TimeSpan.FromSeconds(10d);
            diagnosticMonitorConfiguration.PerformanceCounters.DataSources.Add(performanceCounterConfiguration);
            diagnosticMonitorConfiguration.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(1d);

            DiagnosticMonitor.Start(wadConnectionString, diagnosticMonitorConfiguration);
        }
    }
}