using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Input the length of the array: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int result = Subsequences(n);
        Console.WriteLine($"Maximum possible length of the valid subArray is: {result}.");
    }

    public static int Subsequences(int n)
    {
        List<int> mainArray = new List<int>();

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Number {i + 1}: ");
            mainArray.Add(Convert.ToInt32(Console.ReadLine()));
        }

        mainArray.Sort();
        int result = LongestSubsequence(mainArray);
        return result;
    }

    public static int LongestSubsequence(List<int> mainArray)
    {
        int n = mainArray.Count;
        int largest = 0;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j <= n; j++)
            {
                List<int> subArray = mainArray.Skip(i).Take(j - i).ToList();

                bool sum = IsValid(subArray);

                if (sum)
                {
                    int length = subArray.Count;
                    if (length > largest)
                    {
                        largest = length; 
                    } 
                }
            }
        }
        return largest;
    }

    public static bool IsValid(List<int> subArray)
    {
        int sumOfDiff = 0;
        for (int j = 1; j < subArray.Count; j++)
        {
            int difference = subArray[j] - subArray[j - 1];
            sumOfDiff += difference;
        }
        return sumOfDiff % 2 == 0;
    }
}
