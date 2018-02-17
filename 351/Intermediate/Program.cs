using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PermutationMadness {
    class Program {
        static void Main(string[] args) {
            var input = File.ReadAllText("351\\Intermediate\\Task.txt").Split('\n');
            Dancing(input[0].Remove(input[0].Length - 1, 1), input[1]);//removing one of the additional spaces at the end of a string
        }

        static void Dancing(string row, string dancingData) {
            var commands = dancingData.Split(',');
            var originalRow = row;
            foreach (var move in commands) {
                if (move.Contains("s")) 
                {
                    var steps = int.Parse(new string(move.Where(Char.IsDigit).ToArray()));
                    row = string.Format("{0}{1}", row.Substring(row.Length - steps), row.Substring(0, row.Length - steps));
                } 
                else if (move.Contains("x")) 
                {
                    var steps = move.Split('/');
                    var a = int.Parse(steps[0].Remove(0,1));
                    var b = int.Parse(steps[1]);
                    ReplacePositions(ref row, a, b);
                } 
                else if (move.Contains("p")) 
                {
                    var steps = move.Split('/');
                    var a = int.Parse(steps[0].Remove(0,1));
                    var b = int.Parse(steps[1]);
                    var chars = originalRow.ToCharArray();
                    ReplacePositions(ref row, row.IndexOf(chars[a]), row.IndexOf(chars[b]));
                }
            }
            Console.WriteLine(row);

        }

        static void ReplacePositions(ref string row, int indexA, int indexB) {
            var chars = row.ToCharArray();
            var temp = chars[indexA];
            chars[indexA] = chars[indexB];
            chars[indexB] = temp;
            row = new string(chars);
        }
    }
}