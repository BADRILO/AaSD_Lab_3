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


        public void HeapSort(bool ascending = true)
        {
            int greater(int first, int second)
            {
                return first - second;
            }
            int lower(int first, int second)
            {
                return second - first;
            }

            for (int i = Len / 2; i >= 1; i--)
            {
                this.SettleRoot(i, Len, ascending ? greater : lower);
            }

            for (int end = Len; end > 1;)
            {
                int temp = this[1];

                this[1] = this[end];
                this[end] = temp;

                this.SettleRoot(1, --end, ascending ? greater : lower);
            }

        }

        private void SettleRoot(int root_ind, int last_ind, Comparison<int> comparison)
        {
            int child_ind;

            while (2 * root_ind <= last_ind)           
            {
                if (2 * root_ind < last_ind && comparison(this[2 * root_ind + 1], this[2 * root_ind]) > 0)
                {
                    child_ind = 2 * root_ind + 1;  
                }
                else
                {
                    child_ind = 2 * root_ind;     
                }

                if (comparison(this[root_ind], this[child_ind]) < 0)
                {
                    int temp = this[root_ind];

                    this[root_ind] = this[child_ind];
                    this[child_ind] = temp;

                    root_ind = child_ind;
                }
                else break;
            }
        }

        private int this[int index]
        {
            get 
            {
                return this.arr[index - 1];
            }
            set 
            {
                this.arr[index - 1] = value;
            }
        }
    }
}
