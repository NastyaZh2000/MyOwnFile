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
		public Worker(string ALL)
		{
			var Elems = ALL.Replace(" ", String.Empty).Split(',');
			FirstName = Elems[0];
			LastName = Elems[1];
			Money = Convert.ToInt32(Elems[2]);
		}
		public override string ToString()
		{
			string Result = FirstName + ", " + LastName + ", " + Convert.ToString(Money);
			return Result;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.ToString();
		}
	}
}
