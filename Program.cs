using In_Class_Assignment___Single_Digit;
using System.Diagnostics;


// With Console Apps, it's reading in and getting back strings and since we're not editing the input data, just pass it in as a string and do stuff from there

// Keeps allowing the user to use this program
// Exit via Ctrl + C

// https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
// This has got to be the issue, it's asynchronous
public partial class Program
{
    private static CancellationTokenSource cts = new CancellationTokenSource();

    // https://www.meziantou.net/handling-cancelkeypress-using-a-cancellationtoken.htm
    public static async Task Main(string[] args)
    {
        Console.CancelKeyPress += new ConsoleCancelEventHandler(HandleCancelKeyPress);
        await SingleDigitTask(args, cts.Token);
    }

    private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
        cts.Cancel();
    }

    private static async Task SingleDigitTask(string[] args, CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested) // https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-8.0
            {
                Console.WriteLine("Enter a positive number - press Ctrl + C to terminate the program: ");

                // https://www.bytehide.com/blog/task-run-csharp
                // Getting flashbacks
                // Ok I shouldn't even need to run task for the input string
                string input = Console.ReadLine();

                // Also checks here to make sure that the input isn't 0 and if you input a negative number afterwards, the SingleDigit function handles that
                if (!string.IsNullOrEmpty(input) && input != "0")
                    Console.WriteLine($"Single Digit Result: {SingleDigitCalculation.SingleDigit(input)}\n");

                await Task.Delay(1000, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Terminating program...");
        }
    }
}

/*
Single Digit
In this problem you will start with a single positive number.Subtract adjacent pairs of digits in that number to get the absolute value of their difference. 
Each result is used to generate a new number.Repeat that process as many times as necessary to arrive at a number that is a single digit. Display the final single digit.

This example starts with 584. The first iteration produces the following interim values.

    5 – 8 | = 3 | 8 – 4 | = 4

The process is repeated for 34.

    3 – 4 | = 1

The result is 1.
Input

Prompt for the input as shown below. Enter a single integer value greater than zero. Data will be entered from console. You do not need to edit the input data. Rerun your application to test each test case.
Output

The single digit that is the final result from successively subtracting adjacent digits in the number.

TEST DATA
Enter the number:  5 	5
Enter the number:  98765 	0
Enter the number:  128745 	3

Additional Information:
    You do not need to handle exceptions.
    You can use recursion Naive, Recursion Memorization or Iteration

*/