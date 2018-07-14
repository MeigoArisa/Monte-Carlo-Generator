
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
        
        //double 형의 난수를 생성하기 위한 메소드
        //min값이 max값이 넘지 않는지 체크 후 난수결과값 리턴
        public double NextDouble(double min, double max, Random seed)
        {
            Random random = seed;
            if (min == max)
            {
                return min;
            }
            if (min > max)
            {
                throw new ArgumentOutOfRangeException();
            }
            double returnsum = (random.NextDouble() * (Math.Abs(max - min)) + min);
            random = null;
            return returnsum;
        }


        public async Task<int> speedfile(int value)
        {
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
            Point pos = new Point();
            string FilePath = strFilePath + "testfilespeed.csv";
            string Output = null;
            StringBuilder sbAddress = new StringBuilder();
            unsafe
            {
                for (int i = 0; i < speedvalue; i++)
                {
                    pos.X = NextDouble(0.0000001, 65, new Random(-500 + i));
                    pos.Y = NextDouble((Math.Pow(0.97, pos.X) * (500)) - 50, Math.Pow(0.97, pos.X) * (500) + 50, new Random(1 * i));
                    fixed (double* fixedX = &pos.X, fixedY = &pos.Y)
                    {
                        sbAddress.Append(string.Join(strSeperator, *fixedX, *fixedY, Environment.NewLine));
                    }
                }
            }
            Output = sbAddress.ToString();
            File.AppendAllText(FilePath, Output);
            sbAddress = null;
            Output = null;
        }

        public async Task<int> intervaltestfile(int value)
        {
            intervalvalue = value;
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
            string FilePath = strFilePath + "intervaltestfile.csv";
            Point pos = new Point();
            string Output = null;
            StringBuilder sbAddress = new StringBuilder();

            unsafe
            {
                for (var i = 0; i < intervalvalue; i++)
                {
                    pos.X = NextDouble(0.0000001, 60, new Random(-30+i));
                    pos.Y = NextDouble((-pos.X) / 12 + 30, (-pos.X) / 12 + 40, new Random(1 * i));
                    fixed (double* fixedX = &pos.X, fixedY = &pos.Y)
                    {
                        sbAddress.Append(string.Join(strSeperator, *fixedX, *fixedY, Environment.NewLine));
                    }
                }
            }

            Output = sbAddress.ToString();
            File.AppendAllText(FilePath, Output);
            sbAddress = null;
            Output = null;
        }


        public async Task<int> Weavingtestfile(int value)
        {
            Weavingvalue = value;
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
            string FilePath = strFilePath + "Weavingtestfile.csv";
            Point pos = new Point();
            string Output = null;
            StringBuilder sbAddress = new StringBuilder();

            unsafe
            {
                for (var i = 0; i < Weavingvalue; i++)
                {
                    pos.X = NextDouble(0.0000001, 60, new Random(-7+i));
                    pos.Y = NextDouble((Math.Pow(pos.X, 2) * 0.25) - 7, ((Math.Pow(pos.X, 2) * 0.25) + 7), new Random(1 * i));
                    fixed (double* fixedX = &pos.X, fixedY = &pos.Y)
                    {
                        sbAddress.Append(string.Join(strSeperator, *fixedX, *fixedY, Environment.NewLine));
                    }
                }
            }
            Output = sbAddress.ToString();
            File.AppendAllText(FilePath, Output);
            sbAddress = null;
            Output = null;
        }
    }
}
