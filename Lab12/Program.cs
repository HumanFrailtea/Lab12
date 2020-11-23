using System;
using System.IO;

namespace Lab12
{
	public class NamesDemo
	{
		private string[] nameBoys = new string[1000], nameGirls = new string[1000];
		private int[] numBoys = new int[1000], numGirls = new int[1000];

		public virtual void readData(string fName)
		{

			string[] names = new string[1000];
			int[] total = new int[1000];
			try
			{
				string line = null;
				int countNum = 0;
				StreamReader br = new StreamReader(fName);
				while (!string.ReferenceEquals((line = br.ReadLine()), null))
				{
					string[] data = line.Split(" ", true);
					names[countNum] = data[0];
					total[countNum] = int.Parse(data[1]);
					countNum++;
				}

				if (string.ReferenceEquals(fName, "boynames.txt"))
				{
					this.nameBoys = names;
					this.numBoys = total;
				}
				else
				{
					this.nameGirls = names;
					this.numGirls = total;
				}
				br.Close();

			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("File not found.");
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			catch (IOException e)
			{
				Console.WriteLine("An error contains in input file");
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}
		public static void Main(string[] args)
		{

			NamesDemo nd = new NamesDemo();
			nd.readData("boynames.txt");
			nd.readData("girlnames.txt");
		

		}

	}
	}

	internal static class StringHelper
	{
	
		public static string SubstringSpecial(this string self, int start, int end)
		{
			return self.Substring(start, end - start);
		}

		public static bool StartsWith(this string self, string prefix, int toffset)
		{
			return self.IndexOf(prefix, toffset, System.StringComparison.Ordinal) == toffset;
		}

		public static string[] Split(this string self, string regexDelimiter, bool trimTrailingEmptyStrings)
		{
			string[] splitArray = System.Text.RegularExpressions.Regex.Split(self, regexDelimiter);

			if (trimTrailingEmptyStrings)
			{
				if (splitArray.Length > 1)
				{
					for (int i = splitArray.Length; i > 0; i--)
					{
						if (splitArray[i - 1].Length > 0)
						{
							if (i < splitArray.Length)
								System.Array.Resize(ref splitArray, i);

							break;
						}
					}
				}
			}

			return splitArray;
		}

		public static string NewString(sbyte[] bytes)
		{
			return NewString(bytes, 0, bytes.Length);
		}
		public static string NewString(sbyte[] bytes, int index, int count)
		{
			return System.Text.Encoding.UTF8.GetString((byte[])(object)bytes, index, count);
		}
		public static string NewString(sbyte[] bytes, string encoding)
		{
			return NewString(bytes, 0, bytes.Length, encoding);
		}
		public static string NewString(sbyte[] bytes, int index, int count, string encoding)
		{
			return NewString(bytes, index, count, System.Text.Encoding.GetEncoding(encoding));
		}
		public static string NewString(sbyte[] bytes, System.Text.Encoding encoding)
		{
			return NewString(bytes, 0, bytes.Length, encoding);
		}
		public static string NewString(sbyte[] bytes, int index, int count, System.Text.Encoding encoding)
		{
			return encoding.GetString((byte[])(object)bytes, index, count);
		}

		
		public static sbyte[] GetBytes(this string self)
		{
			return GetSBytesForEncoding(System.Text.Encoding.UTF8, self);
		}
		public static sbyte[] GetBytes(this string self, System.Text.Encoding encoding)
		{
			return GetSBytesForEncoding(encoding, self);
		}
		public static sbyte[] GetBytes(this string self, string encoding)
		{
			return GetSBytesForEncoding(System.Text.Encoding.GetEncoding(encoding), self);
		}
		private static sbyte[] GetSBytesForEncoding(System.Text.Encoding encoding, string s)
		{
			sbyte[] sbytes = new sbyte[encoding.GetByteCount(s)];
			encoding.GetBytes(s, 0, s.Length, (byte[])(object)sbytes, 0);
			return sbytes;
		}
	}

