using System;
using System.ServiceModel;

namespace ClientWCF
{
    // КОНТРАКТ.
    [ServiceContract]
    interface IContractService
    {
        [OperationContract]
        double Method(string s);
    }

    // КЛИЕНТ.
    class Client
    {
        static void Main()
        {
            Console.Title = "Client WCF";

            var channelFactory = new ChannelFactory<IContractService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8888/Test"));

            IContractService service = channelFactory.CreateChannel();

            double digit = service.Method("double");
            Console.WriteLine("Double: {0}", digit);

            // Задержка.
            Console.WriteLine("Press any key to exit client.");
            Console.ReadKey();
        }
    }
}
