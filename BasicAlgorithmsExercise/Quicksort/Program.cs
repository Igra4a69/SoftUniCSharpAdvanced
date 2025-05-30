namespace Quicksort;

using System;

class QuickSort
{
    public static void Sort(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Sort(int[] arr, int left, int right)
    {
        if (left >= right)
            return;

        int pivotIndex = Partition(arr, left, right);
        Sort(arr, left, pivotIndex - 1);
        Sort(arr, pivotIndex + 1, right);
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        int low = left + 1;
        int high = right;

        while (true)
        {
            while (low <= high && arr[low] <= pivot)
                low++;

            while (low <= high && arr[high] > pivot)
                high--;

            if (low > high)
                break;

            int temp = arr[low];
            arr[low] = arr[high];
            arr[high] = temp;
        }

        arr[left] = arr[high];
        arr[high] = pivot;

        return high;
    }
}

class Program
{
    static void Main()
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        QuickSort.Sort(arr);
        Console.WriteLine(string.Join(" ", arr));
    }
}
