using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Ducci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequences = new List<int[]>
            {
                new int[] { 0, 653, 1854, 4063 },
                new int[] { 1, 5, 7, 9, 9 },
                new int[] { 1, 2, 1, 2, 0 },
                new int[] { 10, 12, 41, 62, 31, 50 },
                new int[] { 10, 12, 41, 62, 31}
            };
            Ducci(sequences);
            Console.ReadKey();
        }

        private static void Ducci(List<int[]> input)
        {
            foreach (var sequence in input)
            {
                var sequenceHistory = new List<int[]>();
                var steps = 0;
                ProcessSequence(sequence, sequenceHistory, ref steps);
                Console.WriteLine($"Steps: {steps}");
            }
        }

        private static void ProcessSequence(int[] sequence, List<int[]> history, ref int steps)
        {
            var newSequence = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                newSequence[i] = (i + 1 < sequence.Length) ? Math.Abs(sequence[i] - sequence[i + 1]) : Math.Abs(sequence[i] - sequence[0]);
            }
            DisplaySequence(newSequence);
            history.Add(sequence);
            steps++;
            if (history.Exists(x => x.SequenceEqual(newSequence))) return;
            if (newSequence.Any(a => a != 0))
            {
                ProcessSequence(newSequence, history, ref steps);
            }
        }

        private static void DisplaySequence(int[] sequence)
        {
            foreach (var item in sequence)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
