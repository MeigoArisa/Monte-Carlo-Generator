
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monte_Carlo
{
    class RandomDataGen
    {
        int speedvalue =0;
        int Weavingvalue =0;
        int intervalvalue =0;
        public static string strFilePath = "";
        string strSeperator = ",";

        public async Task<int> speedfile(int value)
        {
            RandomPool.rdPoolStaticAllocLen = value;
            speedvalue = value;
            const int NumOfThread = 1;

            await Task.Factory.StartNew(() => 
            {
                Thread[] threads = new Thread[NumOfThread];
                for (int i = 0; i < NumOfThread; i++)
                {
                    threads[i] = new Thread(Work_speed);
                    threads[i].Start(i);    
                }

                Process currentProcess = Process.GetCurrentProcess();

                foreach (ProcessThread processThread in currentProcess.Threads)
                {
                    processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
                }

                for (int i = 0; i < NumOfThread; i++)
                {
                    threads[i].Join();
                }
            });
            return 0;
        }
        class Point
        {
            public double X;
            public double Y;
        }

        public void Work_speed(object threadId)
        {
            RandomPool radpool = new RandomPool();
            Point pos = new Point();
            string FilePath = strFilePath + "testfilespeed.csv";
            string Output = null;
            StringBuilder sbAddress = new StringBuilder();
            lock (radpool.rdPoolLock)
            {
                unsafe
                {
                    for (int i = 0; i < speedvalue; i++)
                    {
                        pos.X = radpool.NextDouble(0.0000001, 65);
                        pos.Y = radpool.NextDouble((Math.Pow(0.97, pos.X) * (500)) - 50, Math.Pow(0.97, pos.X) * (500) + 50);
                        fixed (double* fixedX = &pos.X, fixedY = &pos.Y)
                        {
                            sbAddress.Append(string.Join(strSeperator, *fixedX, *fixedY, Environment.NewLine));
                        }
                    }
                }
            }
            radpool.rdPoolSwappable = true;
            radpool.rdPoolOffset = RandomPool.rdPoolStaticAllocLen;
            Output = sbAddress.ToString();
            File.AppendAllText(FilePath, Output);
            sbAddress = null;
            Output = null;
        }

        public async Task<int> intervaltestfile(int value)
        {
            intervalvalue = value;
            RandomPool.rdPoolStaticAllocLen = value;
            const int NumOfThread = 1;

            await Task.Factory.StartNew(() =>
            {
                Thread[] threads = new Thread[NumOfThread];

                for (int i = 0; i < NumOfThread; i++)
                {
                    threads[i] = new Thread(Work_interval);
                    threads[i].Start(i);
                }

                Process currentProcess = Process.GetCurrentProcess();

                foreach (ProcessThread processThread in currentProcess.Threads)
                {
                    processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
                }

                for (int i = 0; i < NumOfThread; i++)
                {
                    threads[i].Join();
                }
            });
            return 0;
        }
        
        public unsafe void Work_interval(object threadId)
        {
            RandomPool radpool = new RandomPool();
            string FilePath = strFilePath + "intervaltestfile.csv";
            Point pos = new Point();
            string Output = null;
            StringBuilder sbAddress = new StringBuilder();
            lock (radpool.rdPoolLock)
            {
                unsafe
                {
                    for (var i = 0; i < intervalvalue; i++)
                    {
                        pos.X = radpool.NextDouble(0.0000001, 60);
                        pos.Y = radpool.NextDouble((-pos.X) / 12 + 30, (-pos.X) / 12 + 40);
                        fixed (double* fixedX = &pos.X, fixedY = &pos.Y)
                        {
                            sbAddress.Append(string.Join(strSeperator, *fixedX, *fixedY, Environment.NewLine));
                        }
                    }
                }
            }
            radpool.rdPoolSwappable = true;
            radpool.rdPoolOffset = RandomPool.rdPoolStaticAllocLen;
            Output = sbAddress.ToString();
            File.AppendAllText(FilePath, Output);
            sbAddress = null;
            Output = null;
        }


        public async Task<int> Weavingtestfile(int value)
        {
            Weavingvalue = value;
            RandomPool.rdPoolStaticAllocLen = value;
            const int NumOfThread = 1;

            await Task.Factory.StartNew(() =>
            {
                Thread[] threads = new Thread[NumOfThread];

                for (int i = 0; i < NumOfThread; i++)
                {
                    threads[i] = new Thread(Work_Weaving);
                    threads[i].Start(i);
                }

                Process currentProcess = Process.GetCurrentProcess();

                foreach (ProcessThread processThread in currentProcess.Threads)
                {
                    processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
                }

                for (int i = 0; i < NumOfThread; i++)
                {
                    threads[i].Join();
                }
            });

            return 0;
        }
        
        public unsafe void Work_Weaving(object threadId)
        {
            RandomPool radpool = new RandomPool();
            string FilePath = strFilePath + "Weavingtestfile.csv";
            Point pos = new Point();
            string Output = null;
            StringBuilder sbAddress = new StringBuilder();
            lock (radpool.rdPoolLock)
            {
                unsafe
                {
                    for (var i = 0; i < Weavingvalue; i++)
                    {
                        pos.X = radpool.NextDouble(0.0000001, 60);
                        pos.Y = radpool.NextDouble((Math.Pow(pos.X, 2) * 0.25) - 7, ((Math.Pow(pos.X, 2) * 0.25) + 7));
                        fixed (double* fixedX = &pos.X, fixedY = &pos.Y)
                        {
                            sbAddress.Append(string.Join(strSeperator, *fixedX, *fixedY, Environment.NewLine));
                        }
                    }
                }
            }
            radpool.rdPoolSwappable = true;
            radpool.rdPoolOffset = RandomPool.rdPoolStaticAllocLen;
            Output = sbAddress.ToString();
            File.AppendAllText(FilePath, Output);
            sbAddress = null;
            Output = null;
        }
    }
}
