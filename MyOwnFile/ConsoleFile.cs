using System;
using System.Collections.Generic;

namespace MyOwnFile
{
	class ConsoleFile
	{
		public ConsoleFile(){}
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
		public Tuple<TypeOfMain,List<TypeOfSub>> Read<TypeOfMain,TypeOfSub>()
			where TypeOfMain : class
			where TypeOfSub : class
		{
			string Line = Console.ReadLine();
			string Main = "";
			for(int i=0;i<Line.Length;i++)
			{
				if(Line[i]==':')
				{
					break;
				}
				Main += Line[i];
			}
			TypeOfMain ResultMain = (TypeOfMain)Activator.CreateInstance(typeof(TypeOfMain), Main);
			List<TypeOfSub> ResultSub = new List<TypeOfSub>();
			string Sub = "";
			bool IsSub = false;
			for (int i = 0; i < Line.Length; i++)
			{
				if (Line[i] == '}')
				{
					IsSub = false;
					ResultSub.Add((TypeOfSub)Activator.CreateInstance(typeof(TypeOfSub), Sub));
					Sub = "";
				}
				if(IsSub)
				{
					Sub += Line[i];
				}
				if (Line[i] == '{')
				{
					IsSub = true;
				}
			}
			return new Tuple<TypeOfMain, List<TypeOfSub>>(ResultMain, ResultSub);
		}
	}
}
