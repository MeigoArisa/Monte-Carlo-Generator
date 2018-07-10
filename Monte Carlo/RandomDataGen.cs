using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monte_Carlo
{
    class RandomDataGen
    {
        int speedvalue = 0;
        int Weavingvalue = 0;
        int intervalvalue = 0;
        Random rand = new Random();

        public static string strFilePath = "";
        string strSeperator = ",";
        


        //double 형의 난수를 생성하기 위한 메소드
        //min값이 max값이 넘지 않는지 체크 후 난수결과값 리턴
        double NextDouble(double min, double max)
        {
            if (min == max)
            {
                return max;
            }
            if (min > max)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (min == max)
                return max;
            return rand.NextDouble() * (Math.Abs(max - min)) + min;
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

        private void Work_speed(object threadId)
        {
            double[] xCoords = new double[speedvalue];
            double[] yCoords = new double[speedvalue];

            string FilePath = strFilePath+"testfilespeed.csv";
            

            for (var i = 0; i < speedvalue; i++)
            {
                xCoords[i] = NextDouble(0.01, 65);
                yCoords[i] = NextDouble((Math.Pow(0.97, xCoords[i]) * (500)) - 50, Math.Pow(0.97, xCoords[i]) * (500) + 50);
                File.AppendAllText(FilePath, string.Join(strSeperator, xCoords[i].ToString(), yCoords[i].ToString(), Environment.NewLine));
            }
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


        public void Work_interval(object threadId)
        {
            double[] xCoords = new double[intervalvalue];
            double[] yCoords = new double[intervalvalue];
            string FilePath = strFilePath + "intervaltestfile.csv";

            for (var i = 0; i < intervalvalue; i++)
            {
                xCoords[i] = NextDouble(0.01, 60);
                yCoords[i] = NextDouble((-xCoords[i]) / 12 + 30, (-xCoords[i]) / 12 + 40);
                File.AppendAllText(FilePath, string.Join(strSeperator, xCoords[i].ToString(), yCoords[i].ToString(), Environment.NewLine));
            }
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

        public void Work_Weaving(object threadId)
        {
            double[] xCoords = new double[Weavingvalue];
            double[] yCoords = new double[Weavingvalue];
            string FilePath = strFilePath + "Weavingtestfile.csv";

            for (var i = 0; i < Weavingvalue; i++)
            {
                xCoords[i] = NextDouble(0.01, 60);
                yCoords[i] = NextDouble((Math.Pow(xCoords[i], 2) * 0.25) - 7, ((Math.Pow(xCoords[i], 2) * 0.25) + 7));
                File.AppendAllText(FilePath, string.Join(strSeperator, xCoords[i].ToString(), yCoords[i].ToString(), Environment.NewLine));
            }
        }
    }
}
