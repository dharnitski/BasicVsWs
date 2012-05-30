using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Contract;
using System.ServiceModel.Description;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/Service");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(CounterService), baseAddress))
            {
                // Enable metadata publishing.
                //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

                //host.Description.Behaviors.Add(smb);

                host.AddDefaultEndpoints();

                //var wsContract = new ContractDescription("WSHttpDefault");

                //var wsEndpoint = new ServiceEndpoint(

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }


        //    //// Step 1 of the address configuration procedure: Create a URI to serve as the base address.
        //    //Uri baseAddress = new Uri("http://localhost:8080/Service");

        //    // Step 2 of the hosting procedure: Create ServiceHost
        //    ServiceHost selfHost = new ServiceHost(typeof(CounterService), baseAddress);

        //    //try
        //    //{
        //    //    // Step 3 of the hosting procedure: Add a service endpoint.
        //    //    selfHost.AddServiceEndpoint(
        //    //        typeof(ICounter),
        //    //        new BasicHttpBinding(), "Base");

        //    //    selfHost.AddServiceEndpoint(
        //    //        typeof(ICounter),
        //    //        new WSHttpBinding(), "Ws");


        //    //    // Step 4 of the hosting procedure: Enable metadata exchange.
        //    //    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        //    //    smb.HttpGetEnabled = true;
        //    //    selfHost.Description.Behaviors.Add(smb);

        //    //    // Step 5 of the hosting procedure: Start (and then stop) the service.
        //    //    selfHost.Open();
        //    Console.WriteLine("The service is ready.");
        //    Console.WriteLine("Press <ENTER> to terminate service.");
        //    Console.WriteLine();
        //    Console.ReadLine();

        //    //    // Close the ServiceHostBase to shutdown the service.
        //    //    selfHost.Close();
        //    //}
        //    //catch (CommunicationException ce)
        //    //{
        //    //    Console.WriteLine("An exception occurred: {0}", ce.Message);
        //    //    selfHost.Abort();
        //    //}

    //    }
    //}
}
