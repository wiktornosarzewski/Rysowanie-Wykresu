using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chartTest
{
    internal class BubbleSort
    {
        private Random gen = new Random();
        private int[]data;
        private DateTime start, stop;
        public Double Duration
        { 
            get
            {
                if (start!=null && stop != null)
                {
                    return (stop-start).TotalMilliseconds;
                }
                else
                { 
                    return 0; 
                }
            }
        }
        public BubbleSort(Int64 n)
        { 
            data = new int[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = gen.Next();
            }
        }
        public void Sort()
        {
            start = DateTime.Now;
            for(int i=0; i < data.Length; i++)
            {
                for (int j = 0; j<data.Length; j++) 
                {
                    if (data[i] > data[j])
                    {
                        int tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }
                }    
            }
            stop = DateTime.Now;
        }
    }
}
