using System;

namespace MyOwnFile
{
	class Company : IFormattable
	{
		string Name { set; get; }
		string Adress { set; get; }
		public Company(string _Name = "", string _Adress = "")
		{
			Name = _Name;
			Adress = _Adress;
		}
		public Company(string ALL)
		{
			var Elems = ALL.Replace(" ", String.Empty).Split(',');
			Name = Elems[0];
			Adress = Elems[1];
		}
		public override string ToString()
		{
			string Result = Name + ", " + Adress;
			return Result;
		}
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.ToString();
		}
	}
}
