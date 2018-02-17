using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PermutationMadness 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var input = File.ReadAllText("351\\Intermediate\\Task2.txt").Split('\n');
            Console.WriteLine($"Input: {input[0]}");
            Dancing(input[0].Remove(input[0].Length - 1, 1), input[1]);//removing one of the additional spaces at the end of a string
        }

        static void Dancing(string row, string dancingData) 
        {
            var commands = dancingData.Split(',');
            var originalRow = row;
            foreach (var move in commands) 
            {
                if (move.Contains("s")) 
                {
                    var steps = int.Parse(new string(move.Where(Char.IsDigit).ToArray()));
                    row = string.Format("{0}{1}", row.Substring(row.Length - steps), row.Substring(0, row.Length - steps));
                } 
                else if (move.Contains("x"))
                {
                    GetIndex(move, out int a, out int b);
                    ReplacePositions(ref row, a, b);
                }
                else 
                {
                    GetIndex(move, out int a, out int b);
                    var chars = originalRow.ToCharArray();
                    ReplacePositions(ref row, row.IndexOf(chars[a]), row.IndexOf(chars[b]));
                }
            }
            Console.WriteLine($"Output: {row}");
        }

        private static void GetIndex(string move, out int a, out int b)
        {
            var steps = move.Split('/');
            a = int.Parse(steps[0].Remove(0, 1));
            b = int.Parse(steps[1]);
        }

        static void ReplacePositions(ref string row, int indexA, int indexB) 
        {
            var chars = row.ToCharArray();
            var temp = chars[indexA];
            chars[indexA] = chars[indexB];
            chars[indexB] = temp;
            row = new string(chars);
        }
    }
}