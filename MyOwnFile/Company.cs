using System;

namespace MyOwnFile
{
	class Company : IFormattable
	{
		string Name { set; get; }
		string Adress { set; get; }
		public Company(string _Name = "", string _Adress ="")
		{
			Name = _Name;
			Adress = _Adress;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			throw new NotImplementedException();
		}
	}
}
