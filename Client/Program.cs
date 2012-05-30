using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.CounterProxy;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace Client
{
    class Program
    {
        private static int runCount = 100;

        static void Main(string[] args)
        {
            var endpoints = GetEndpointsSection();

            var endpointNames = endpoints.OfType<ChannelEndpointElement>().Select(e => e.Name).ToList();

            endpointNames.ForEach(n => WarmUpService(n));

            endpointNames.ForEach(n => RunTestForOneEndpoint(n));

            Console.WriteLine("Press <Enter> to exit.");
            Console.ReadLine();
        }

        private static ChannelEndpointElementCollection GetEndpointsSection()
        {
            Configuration config =
          //ConfigurationManager.OpenMappedExeConfiguration(
              //new ExeConfigurationFileMap() { ExeConfigFilename = path },
              ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);
            return serviceModel.Client.Endpoints;
        }

        private static void RunTestForOneEndpoint(string endpointConfigurationName)
        {
            Console.WriteLine("Running test for configuration '{0}'", endpointConfigurationName);

            var meter = new PerformanceMeter(endpointConfigurationName);
            var testResult = meter.Run(runCount, meter.RunAllCallsInOneContext);
            Console.WriteLine(testResult.ToString());
            testResult = meter.Run(runCount, meter.RunAllCallsInSeparateContext);
            Console.WriteLine(testResult.ToString());
            Console.WriteLine();
        }

        private static void WarmUpService(string endpointConfigurationName)
        {
            Console.WriteLine("Running test for configuration '{0}'", endpointConfigurationName);

            var meter = new PerformanceMeter(endpointConfigurationName);
            var testResult = meter.Run(1, meter.RunAllCallsInSeparateContext);

            Console.WriteLine(testResult.ToString());
            Console.WriteLine();
        }
    }
}
