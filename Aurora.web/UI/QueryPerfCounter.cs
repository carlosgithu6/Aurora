using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Aurora.Web.UI
{
   public  class QueryPerfCounter
    {
        private long start;
        private long stop;
        private long frequency;
        Decimal multiplier = new Decimal(1.0e9);

        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        public QueryPerfCounter()
        {
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
        }
        public void Start()
        {
            QueryPerformanceCounter(out start);
        }

        public void Stop()
        {
            QueryPerformanceCounter(out stop);
        }

        public double Duration(int iterations)
        {
            return ((((double)(stop - start) *
            (double)multiplier) /
            (double)frequency) / iterations);
        }
        
    }
}
