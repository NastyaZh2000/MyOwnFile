using System;
using System.Collections.Generic;

namespace MyOwnFile
{
	class File
	{
		string FileName;
		public File(string _FileName)
		{
			FileName = _FileName;
		}
		public void Write<TypeOfMain, TypeOfSub>(TypeOfMain MainElem, List<TypeOfSub> SubElem)
			where TypeOfMain : IFormattable
			where TypeOfSub : IFormattable
		{
			string Result = Convert.ToString(MainElem) + " : ";
			int N = SubElem.Count;
			for (int i = 0; i < N - 1; i++)
			{
				Result += "{ " + Convert.ToString(SubElem[i]) + " }; ";
			}
			Result += "{ " + Convert.ToString(SubElem[N - 1]) + " }.";
			Console.WriteLine(Result);
		}
	}
}
