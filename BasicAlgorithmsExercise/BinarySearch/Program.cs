namespace BinarySearch;

using System;

class BinarySearchAlgorithm
{
    public static int BinarySearch(int[] arr, int key)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == key)
                return mid;

            if (arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

class Program
{
    static void Main()
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int key = int.Parse(Console.ReadLine());
        Console.WriteLine(BinarySearchAlgorithm.BinarySearch(arr, key));
    }
}
