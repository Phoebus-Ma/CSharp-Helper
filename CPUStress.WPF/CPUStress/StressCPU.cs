using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CPUStress
{
    internal class StressCPU
    {
        private static int usingCores = 1;
        private static int busyTimes = 0;
        private static bool isQuitStress = false;

        private static List<Thread> StressThreads = new List<Thread>();

        /* Set using processor count. */
        public static int SetUseCoresCount(int Value)
        {
            if (Value > 0)
            {
                if (Value > Environment.ProcessorCount)
                    Value = Environment.ProcessorCount;

                usingCores = Value;
            }

            return 0;
        }

        /* Set CPU workload value. */
        public static int SetWorkloadValue(int Value)
        {
            if ((Value > 0) && (Value < 101))
                busyTimes = Value;

            return 0;
        }

        /* Stress CPU callback function. */
        private static void StressCPU_Callback()
        {
            int idleCount = 0;
            int busyCount = 0;
            long startTime = 0;

            while (!isQuitStress)
            {
                startTime = DateTime.UtcNow.Ticks;

                busyCount = busyTimes * 10000;
                while ((DateTime.UtcNow.Ticks - startTime) < busyCount) ;

                idleCount = (100 - busyTimes) * 10;
                Thread.Sleep(idleCount);
            }
        }

        /* Create test thread(s). */
        public static int CreateStreeCPUThread()
        {
            for (int i = 0; i < usingCores; i++)
            {
                Thread thread = new Thread(StressCPU_Callback);

                StressThreads.Add(thread);
            }

            return 0;
        }

        /* Start work thread(s). */
        public static int StartWorkThreads()
        {
            foreach (var thread in StressThreads)
            {
                thread.Start();
            }

            return 0;
        }

        /* Stop work thread(s). */
        public static int StopWorkThreads()
        {
            isQuitStress = true;

            return 0;
        }
    }
}
