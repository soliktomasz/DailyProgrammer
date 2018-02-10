using System;
using System.Collections.Generic;

namespace inter {
    class Program {
        static void Main (string[] args) {
            int[] transactions = { 0 ,-3, 5, -4, -2, 3, 1, 0 };
            int[] transactions1 = { 3, -2, 2, 0, 3, 4, -6, 3, 5, -4, 8 };
            int[] transactions2 = { 9, 0, -5, -4, 1, 4, -4, -9, 0, -7, -1 };
            int[] transactions3 = { 9, -7, 6, -8, 3, -9, -5, 3, -6, -8, 5 };
            ProcessTransactions(transactions);
            Console.WriteLine("");
            ProcessTransactions(transactions1);
            Console.WriteLine("");
            ProcessTransactions(transactions2);
            Console.WriteLine("");
            ProcessTransactions(transactions3);
        }

        private static void ProcessTransactions(int[] transactions){
             for (int i = 0; i < transactions.Length; i++) {
                if (BeforIndexSum(i, transactions) == AfterIndexSum(i, transactions)) {
                    Console.Write(i + " ");
                }
            }
        }

        private static int BeforIndexSum (int index, int[] transactions) {
            int sum = 0;
            if(index == 0) return sum;
            for (int i = 0; i < index; i++) {
                sum += transactions[i];
            }
            return sum;
        }

        private static int AfterIndexSum (int index, int[] transactions) {
            int sum = 0;
            if(index == transactions.Length-1) return sum;
            for (int i = transactions.Length-1; i > index; i--) {
                sum += transactions[i];
            }
            return sum;
        }
    }
}