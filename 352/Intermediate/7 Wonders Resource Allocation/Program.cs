//https://www.reddit.com/r/dailyprogrammer/comments/7z8hrm/20180221_challenge_352_intermediate_7_wonders/
using System;
using System.Collections.Generic;
using System.Linq;
namespace _7_Wonders_Resource_Allocation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "W/B/S/O", "W", "S/B", "S", "W/S" };
            var goalPattern = "WWSSS";
            Array.Sort(input, (x, y) => x.Length.CompareTo(y.Length));
            Solve(input, goalPattern);
            //foreach (var item in input)
            //{
            //    Console.WriteLine(item);
            //}
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
            foreach (var character in goalPattern.ToCharArray())
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
            foreach (var item in dictionary.Values)
            {
                
            }
            foreach(var item in dictionary.Values)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item[i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(goalPattern);
        }
    }
}
