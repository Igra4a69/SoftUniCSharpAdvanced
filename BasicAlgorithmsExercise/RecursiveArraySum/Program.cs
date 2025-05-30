namespace RecursiveArraySum;


class Program
{
    static int RecursiveSum(int[] arr, int index = 0)
    {
        if (index >= arr.Length)
            return 0;

        return arr[index] + RecursiveSum(arr, index + 1);
    }

    static void Main()
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Console.WriteLine(RecursiveSum(numbers));
    }
}
