using System;
using System.ServiceModel;

namespace ServiceWCF
{
	// КОНТРАКТ.
	[ServiceContract]
	interface IContractService
	{
		[OperationContract]
		double Method(string s);
	}


	// СЕРВИС.
	class MyService : IContractService
	{
		public double Method(string s)
		{
			Console.WriteLine("Got request: " + s);

			if (s == "double")
				return 777.79;

			return 0;
		}
	}


	// ХОСТ.
	class Service
	{
		static void Main(string[] args)
		{
			Console.Title = "Server WCF";

			ServiceHost serviceHost = new ServiceHost(typeof(MyService), new Uri("http://localhost:8888/Test"));

			serviceHost.AddServiceEndpoint(typeof(IContractService), new BasicHttpBinding(), "");

			serviceHost.Open();

			Console.WriteLine("Press any key to terminate the service.");
			Console.ReadKey();

			serviceHost.Close();
		}
	}
}
