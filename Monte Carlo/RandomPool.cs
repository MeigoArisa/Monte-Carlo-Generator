using System;
using System.Threading;

namespace Monte_Carlo
{
    public class RandomPool
    {
        public static int rdPoolStaticAllocLen = 1000000;

        private Random   rdDevice = new Random();

        public int      rdPoolOffset;
        private Double[] rdPoolCur;

        public Object   rdPoolLock = new object();
        public bool     rdPoolSwappable;
        private Double[] rdPoolNew;

        unsafe public RandomPool()
        {
            rdDevice = new Random();

            lock (rdPoolLock)
            {
                rdPoolCur = new double[rdPoolStaticAllocLen];
                rdPoolNew = new double[rdPoolStaticAllocLen];

                unsafe
                {
                    fixed (Double* curPool = rdPoolCur, newPool = rdPoolNew)
                    {
                        for (int i = 0; i < rdPoolStaticAllocLen; ++i)
                        {
                            curPool[i] = rdDevice.NextDouble();
                            newPool[i] = rdDevice.NextDouble();
                        }
                    }
                }

                rdPoolSwappable = true;
                rdPoolOffset = rdPoolStaticAllocLen;
            }
        }

        ~RandomPool()
        {
            lock (rdPoolLock)
            {
                rdPoolCur = null;
                rdPoolNew = null;
            }
        }

        private void Swap(ref Double[] lhs, ref Double[] rhs)
        {
            Double[] tmp = lhs;
            lhs = rhs;
            rhs = lhs;
        }

        private void GenerateNewPool()
        {
            unsafe
            {
                fixed (Double* newPool = rdPoolNew)
                {
                    for (int i = 0; i < rdPoolStaticAllocLen; ++i)
                    {
                        newPool[i] = rdDevice.NextDouble();
                    }
                }
            }

            rdPoolSwappable = true;
        }

        private Double NextDoubleImpl()
        {
            lock (rdPoolLock)
            {
                if (rdPoolOffset == 0)
                {
                    while (!rdPoolSwappable)
                    {
                        Thread.Yield();
                    }

                    Swap(ref rdPoolCur, ref rdPoolNew);
                    rdPoolSwappable = false;
                    rdPoolOffset = rdPoolStaticAllocLen;

                    new Thread(GenerateNewPool);
                }

                return rdPoolCur[--rdPoolOffset];
            }
        }

        public Double NextDouble(Double minRange, Double maxRange)
        {
            return NextDoubleImpl() * (Math.Abs(maxRange - minRange) + minRange);
        }
    }
}
