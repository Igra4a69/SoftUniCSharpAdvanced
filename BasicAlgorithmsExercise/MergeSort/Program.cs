namespace MergeSort;

using System;

class MergeSort
{
    public static void Sort(int[] arr)
    {
        if (arr.Length <= 1)
            return;

        int[] aux = new int[arr.Length];
        Sort(arr, aux, 0, arr.Length - 1);
    }

    private static void Sort(int[] arr, int[] aux, int left, int right)
    {
        if (left >= right)
            return;

        int mid = (left + right) / 2;
        Sort(arr, aux, left, mid);
        Sort(arr, aux, mid + 1, right);
        Merge(arr, aux, left, mid, right);
    }

    private static void Merge(int[] arr, int[] aux, int left, int mid, int right)
    {
        int i = left, j = mid + 1, k = left;

        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
                aux[k++] = arr[i++];
            else
                aux[k++] = arr[j++];
        }

        while (i <= mid)
            aux[k++] = arr[i++];
        while (j <= right)
            aux[k++] = arr[j++];

        for (int index = left; index <= right; index++)
            arr[index] = aux[index];
    }
}

class Program
{
    static void Main()
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        MergeSort.Sort(arr);
        Console.WriteLine(string.Join(" ", arr));
    }
}
