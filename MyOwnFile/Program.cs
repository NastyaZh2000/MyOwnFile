using System.Collections.Generic;

namespace MyOwnFile
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleFile x = new ConsoleFile();
			BinaryFile y = new BinaryFile("C:/Users/Shop/source/repos/Programming_Univer/MyOwnFile/MyOwnFile/BinaryFileToWork.txt");
			Company tmp = new Company("CompanyName", "CompanyAdress");
			List<Worker> arr = new List<Worker>
			{
				new Worker("FirstName1", "LastName1", 10000),
				new Worker("FirstName2", "LastName2", 20000),
				new Worker("FirstName3", "LastName3", 30000)
			};
			y.Write(tmp, arr);//write in binary file
			var tmp1 = y.Read<Company, Worker>();//read from binary file
			x.Write(tmp1[0].Item1, tmp1[0].Item2);
		}
	}
}
