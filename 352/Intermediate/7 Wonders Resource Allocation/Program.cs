//https://www.reddit.com/r/dailyprogrammer/comments/7z8hrm/20180221_challenge_352_intermediate_7_wonders/
using System;
using System.Collections.Generic;
using System.Linq;
namespace _7_Wonders_Resource_Allocation
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "W/B/S/O", "W", "S/B", "S", "W/S" };
            string[] input2 = { "A/B/D/E", "A/B/E/F/G", "A/D", "A/D/E", "A/D/E", "B/C/D/G", "B/C/E", "B/C/E/F", "B/C/E/F", "B/D/E", "B/D/E", "B/E/F", "C/D/F", "C/E", "C/E/F/G", "C/F", "C/F", "D/E/F/G", "D/F", "E/G" };
            var goalPattern = "WWSSS";
            var goalPattern2 = "AABCCCCCCDDDEEEEFFGG";
            Array.Sort(input, (x, y) => x.Length.CompareTo(y.Length));
            Array.Sort(input2, (x, y) => x.Length.CompareTo(y.Length));
            Solve(input, goalPattern);
            Solve(input2, goalPattern2);
            Console.ReadKey();
        }

        private static void Solve(string[] input, string goalPattern)
        {
            foreach (var item in input.Where(s => s.Length == 1))
            {
                var index = goalPattern.IndexOf(char.Parse(item));
                goalPattern = goalPattern.Remove(index, 1);
                if (index == -1)
                {
                    Console.WriteLine("Goal pattern impossible to achive");
                    return;
                }
            }
            var dictionary = new Dictionary<int, int[]>();
            var items = input.Where(s => s.Length > 1).ToArray();
            var key = 0;
            foreach (var character in goalPattern)
            {
                var list = new List<int>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Contains(character))
                    {
                        list.Add(i);
                    }
                }
                list.Sort();
                dictionary.TryAdd(key, list.ToArray());
                key++;
            }
            if (CheckDictionary(dictionary))
            {
                Console.WriteLine("Combination found\n");
            }
            else
            {
                Console.WriteLine("Goal pattern impossible to achive");
            }
        }

        private static bool CheckDictionary(Dictionary<int, int[]> values)
        {
            var solution = new List<int>();
            var index = -1;
            var ordered = values.OrderBy(v => v.Value.Length);
            foreach (var item in ordered)
            {
                foreach (var value in item.Value)
                {
                    if (solution.Count > 0 && solution[index] != value)
                    {
                        if (!solution.Contains(value))
                        {
                            solution.Add(value);
                            break;
                        }
                    }
                    else if (solution.Count == 0)
                    {
                        solution.Add(value);
                        break;
                    }
                }
                index++;
            }
            var orderedDictionary = ordered.ToDictionary(d => d.Key, d => d.Value);
            ShowResult(orderedDictionary, solution);
            if (solution.Count != values.Count && orderedDictionary[0].Length != 1)
            {
                var firstElement = orderedDictionary.Values.First();
                var temp = firstElement.ToList();
                temp.RemoveAt(0);
                orderedDictionary[0] = temp.ToArray();
                return CheckDictionary(orderedDictionary);
            }
            return solution.Count == values.Count;
        }

        private static void ShowResult(Dictionary<int, int[]> dictionary, List<int> solution)
        {
            foreach (var item in dictionary.Values)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item[i] + " ");
                }
                Console.WriteLine();
            }
            Console.Write("Solution: ");
            foreach (var item in solution)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
