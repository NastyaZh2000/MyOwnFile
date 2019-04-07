using System;
using System.Collections.Generic;
using System.IO;

namespace MyOwnFile
{
	class BinaryFile
	{
		string BinaryFilePath;
		public BinaryFile(string _BinaryFilePath = "")
		{
			BinaryFilePath = _BinaryFilePath;
		}
		public void WriteFrameCodesAsBinary(string frameCode)
		{
			using (FileStream fileStream = new FileStream(BinaryFilePath, FileMode.Create))
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				binaryWriter.Write(frameCode);
			}
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

			try
			{
				this.WriteFrameCodesAsBinary(Result);
			}
			catch (IOException e)
			{
				Console.WriteLine(e.Message + "\n Cannot open file.");
				return;
			}


		}
		public Tuple<TypeOfMain, List<TypeOfSub>> Read<TypeOfMain, TypeOfSub>()
			where TypeOfMain : class
			where TypeOfSub : class
		{
			FileStream readStream = new FileStream(BinaryFilePath, FileMode.Open);
			BinaryReader readBinary = new BinaryReader(readStream);
			string Line = readBinary.ReadString();
			string Main = "";
			for (int i = 0; i < Line.Length; i++)
			{
				if (Line[i] == ':')
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
				if (IsSub)
				{
					Sub += Line[i];
				}
				if (Line[i] == '{')
				{
					IsSub = true;
				}
			}
			return (new Tuple<TypeOfMain, List<TypeOfSub>>(ResultMain, ResultSub));

		}
	}
}
