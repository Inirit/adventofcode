using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
	class Program
	{
		static void Main(string[] args)
		{
			var values = GetValues(@".\input\input.txt");
			var aggregateValue = Part1(values);
			var firstDuplicate = Part2(values);

			Console.WriteLine($"Results: [Value Count: {values.Length}] [Aggregate Value: {aggregateValue}] [First Duplicate: {firstDuplicate}]");

			Console.WriteLine("Press enter to continue...");

			Console.ReadLine();
		}

		static int[] GetValues(string filePath)
		{
			var values = File.ReadAllLines(filePath)
				.Select(line => int.Parse(line.Trim()))
				.ToArray();

			return values;
		}

		static int Part1(IEnumerable<int> values)
		{
			var result = values.Aggregate((x, y) => x + y);

			return result;
		}

		static int Part2(int[] values)
		{
			var numbersEncountered = new HashSet<int>();
			var duplicateFound = false;
			var currentValue = 0;

			for (var i = 0; i < values.Length && !duplicateFound; i++, i %= values.Length)
			{
				currentValue += values[i];

				if (numbersEncountered.Contains(currentValue))
				{
					duplicateFound = true;
				}
				else
				{
					numbersEncountered.Add(currentValue);
				}
			}

			return currentValue;
		}
	}
}
