# In Class Assignment - Single Digit

## Single Digit
In this problem you will start with a single positive number. Subtract adjacent pairs of digits in that number to get the absolute value of their difference. Each result is used to generate a new number. Repeat that process as many times as necessary to arrive at a number that is a single digit. Display the final single digit.

This example starts with 584. The first iteration produces the following interim values.

5 – 8 | = 3 | 8 – 4 | = 4
The process is repeated for 34.

3 – 4 | = 1
The result is 1.

Input
Prompt for the input as shown below. Enter a single integer value greater than zero. Data will be entered from console. You do not need to edit the input data. Rerun your application to test each test case.

Output
The single digit that is the final result from successively subtracting adjacent digits in the number.

Test Data
Input	Output
Enter the number:  5	5
Enter the number:  98765	0
Enter the number:  128745	3
Additional Information:

You do not need to handle exceptions.
You can use recursion Naive, Recursion Memorization or Iteration