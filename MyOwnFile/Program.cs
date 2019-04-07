using System.Collections.Generic;

namespace MyOwnFile
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleFile x = new ConsoleFile();
			Company tmp = new Company("CompanyName", "CompanyAdress");
			List<Worker> arr = new List<Worker>();
			arr.Add(new Worker("FirstName1", "LastName1", 10000));
			arr.Add(new Worker("FirstName2", "LastName2", 20000));
			arr.Add(new Worker("FirstName3", "LastName3", 30000));
			x.Write(tmp, arr);
			var tmp1 = x.Read<Company, Worker>();
			x.Write(tmp1.Item1, tmp1.Item2);
		}
	}
}
