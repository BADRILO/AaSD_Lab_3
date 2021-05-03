using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            int[] arr = new int[50];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 1000);
            }

            ListWithHeapsort list = new(arr);
            list.printList();
            list.HeapSort();
            list.printList();
        }
    }
}
