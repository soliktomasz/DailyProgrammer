using System;
using System.Collections.Generic;

namespace inter {
    class Program {
        static void Main (string[] args) {
            int[] transactions = { 0 ,-3, 5, -4, -2, 3, 1, 0 };
            for (int i = 0; i < transactions.Length; i++) {
                if (BeforIndexSum(i, transactions) == AfterIndexSum(i, transactions)) {
                    Console.WriteLine(i);
                }
            }
        }

        public static int BeforIndexSum (int index, int[] transactions) {
            int sum = 0;
            if(index == 0) return transactions[0];
            for (int i = 0; i < index; i++) {
                sum += transactions[i];
            }
            return sum;
        }

        public static int AfterIndexSum (int index, int[] transactions) {
            int sum = 0;
            if(index == transactions.Length-1) return transactions[index];
            for (int i = transactions.Length-1; i > index; i--) {
                sum += transactions[i];
            }
            return sum;
        }
    }
}