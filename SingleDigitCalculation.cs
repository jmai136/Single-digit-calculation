using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace In_Class_Assignment___Single_Digit
{
    public static class SingleDigitCalculation
    {
        // Memo equivalent, stores the pairs of strings
        // Fuck it, new plan, can't use queues, I can't figure out how the hell I could dequeue the adjacent, but still use it for the next iteration with the recursive call
        // Trying to store the difference as part of the queue ends up getting a stack overflow
        // Also this is what happens when you suck at math and don't understand it until 2 hours later

        // Ok, we're going to store it as a dictionary instead, need to store those adjacent values to pass in somehow
        // So string as keys, and then the iterations will be stored as the values? As in after all, we will always have a new number after subtracting per iteration, so store that
        private static Dictionary<string, int>memo = new Dictionary<string, int>();

        public static string SingleDigit(string n)
        {
            // Just for logging purposes, need to check sure it matches the math
            // Wait, how the hell am I getting duplicate key pair values
            // Got it, it's just different iterations
            /*Console.WriteLine("\nSINGLE DIGIT");

            foreach (KeyValuePair<string, int> pair in memo)
                Console.WriteLine($"Key: {pair.Key} Value: {pair.Value}");*/

            // Makes sure that user can't not input a number
            int number;
            if (!int.TryParse(n, out number) || n.Length <= 0)
                return "Enter a number, please.";

            // Accounts for negative numbers
            if (number < 0)
                return "Must enter a positive number, please.";

            // This is for if you pass in a single digit already from the beginning as well as the recursive function working
            // Eventually you're going to have to whittle down to 1 in terms of n's length and since this runs first, will never run into an issue where it does contain the key
            // but the actual value's not one digit
            if (n.Length == 1)
                return n;

            // This assumes that we've gotten the result down to one digit after various iterations
            // Because the default's passing the function back again, the newNumber wouldn't be added as a key already

            // Ok this isn't going to work on repeat because of issues related to storing values
            if (memo.ContainsKey(n))
            {
                // Let's say it contains the key, we've ran it before, that means there's gonna be a value associated with it,
                // Like first time run 384, that's gonna be fine, but second time we got 384, 54

                // So grab that
                int possibleSingleDigit = memo[n];
                string v = possibleSingleDigit.ToString();

                // Check to make sure if it's a single digit, if it's not then recursively run it again
                if (possibleSingleDigit > 9)
                    return SingleDigit(v);

                // Otherwise just return the value as it is
                return v;
            }

            // Modify the original string to now apply the difference to replace at the specific index
            // Problem is how would this work with odd lengths, actually it should because it'll always stop before it reaches the last index
            // 0 - 1, 1 - 2, v.v.

            string newNumber = "";

            for (int i = 0; i < n.Length - 1; i++)
            {
                // Need to convert to char? Or would it recognise it, the goal is to slot it like elements, 584 becomes 34, so 0 - 3, 1 - 4
                // Can't insert like this, otherwise the math's wrong for 3? How does 3's math work?
                newNumber = newNumber.Insert(i, Math.Abs(n[i] - n[i + 1]).ToString());
            }

            // Console.WriteLine($"Before Trimmed: {newNumber}");

            // Is it ignoring 0 in front of a number? Are we just ignoring leading zeroes? Otherwise it's not gonna work
            // Probably should do a check or regex here to check whether 0's at the beginning of a string and cut that out
            // Ok, why isn't this working
            if (newNumber.StartsWith("0") && newNumber.Length >= 2)
                newNumber = newNumber.TrimStart(new Char[] { '0' }); // REMEMBER, VALUE, NOT REFERENCE, ASSIGN

            // So it's just gonna get rid of all leading instances, so it's possible for the string to be empty
            if (newNumber.Length <= 0)
                newNumber = "0";

           // Console.WriteLine($"After Trimmed: {newNumber}");

            memo[n] = int.Parse(newNumber);

            // Please for the love of God, let this work, it should because you recursively run it, it runs and passes the new new number
            // Haha, got you, memoized recursion
            return SingleDigit(newNumber);
        }
    }
}
