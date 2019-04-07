using System;

namespace MyOwnFile
{
	class Worker : IFormattable
	{
		string FirstName { set; get; }
		string LastName { set; get; }
		int Money { set; get; }
		public Worker(string _FirstName = "", string _LastName = "", int _Money = 3200)
		{
			FirstName = _FirstName;
			LastName = _LastName;
			Money = _Money;
		}
		

		public string ToString(string format, IFormatProvider formatProvider)
		{
			throw new NotImplementedException();
		}
	}
}
