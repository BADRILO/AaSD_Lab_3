using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ListWithHeapsort
    {
        private int[] arr;
        public int Len { get; private set; }

        public ListWithHeapsort() 
            : this(Array.Empty<int>()) { }
        public ListWithHeapsort(int item) 
            : this(items: item){ }
        public ListWithHeapsort(params int[] items)
        {
            this.arr = new int[items.Length < 5 ? 10 : items.Length * 2];
            this.Len = items.Length;

            for (int i = 0; i < Len; i++)
            {
                this.arr[i] = items[i];
            }
        }


        public void printList()
        {
            for (int i = 0; i < Len; i++)
            {
                Console.WriteLine($"№{i, 2}: {this.arr[i]};");
            }
            Console.WriteLine("\n\n");
        }
        public void add(int item)
        {
            if (this.arr.Length == this.Len)
            {
                ListWithHeapsort new_list = new ListWithHeapsort(this.arr);

                this.arr = new_list.arr;
                this.Len = new_list.Len;
            }
            this.arr[Len++] = item;
        }
    }
}
