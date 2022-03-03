using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ProcessAffinity
{
    internal class ProcessMask
    {
        /* Open Process. */
        public static int OpenProcess(int pid, out IntPtr procHandle)
        {
            int status = -1;

            procHandle = ProcessLibrary.OpenProcess(
                ProcessLibrary.PROCESS_SET_INFORMATION |
                ProcessLibrary.PROCESS_QUERY_INFORMATION |
                ProcessLibrary.PROCESS_SET_QUOTA |
                ProcessLibrary.PROCESS_TERMINATE,
                false,
                (uint)pid
            );

            if (IntPtr.Zero != procHandle)
                status = 0;

            return status;
        }

        /* CPU Affinity Mask. */
        public static bool SetProcessAffinityMask(IntPtr procHandle, UIntPtr cpuMask)
        {
            bool ret = false;
            UInt64 maxValue = 0;

            /**
             * Example:
             * The value for cpuMask.ToUInt64():
             * 1 == 0000 0001 == CPU 0.
             * 2 == 0000 0010 == CPU 1.
             * 3 == 0000 0011 == (CPU 0 + CPU 1).
             * 15 == 0000 1111 == (CPU 0 + CPU 1 + CPU 2 + CPU 3).
             */
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                maxValue = maxValue << 1;
                maxValue += 1;
            }

            if (cpuMask.ToUInt64() <= maxValue)
                ret = ProcessLibrary.SetProcessAffinityMask(procHandle, cpuMask);

            return ret;
        }

        /* Priority. */
        public static bool SetPriorityClass(IntPtr procHandle, int prioSelect)
        {
            uint prioIndex = ProcessLibrary.NORMAL_PRIORITY_CLASS;

            switch (prioSelect)
            {
                case 1:
                    prioIndex = ProcessLibrary.NORMAL_PRIORITY_CLASS;
                    break;

                case 2:
                    prioIndex = ProcessLibrary.IDLE_PRIORITY_CLASS;
                    break;

                case 3:
                    prioIndex = ProcessLibrary.HIGH_PRIORITY_CLASS;
                    break;

                case 4:
                    prioIndex = ProcessLibrary.REALTIME_PRIORITY_CLASS;
                    break;

                case 5:
                    prioIndex = ProcessLibrary.BELOW_NORMAL_PRIORITY_CLASS;
                    break;

                case 6:
                    prioIndex = ProcessLibrary.ABOVE_NORMAL_PRIORITY_CLASS;
                    break;

                case 7:
                    prioIndex = ProcessLibrary.PROCESS_MODE_BACKGROUND_BEGIN;
                    break;

                case 8:
                    prioIndex = ProcessLibrary.PROCESS_MODE_BACKGROUND_END;
                    break;

                default:
                    prioIndex = ProcessLibrary.NORMAL_PRIORITY_CLASS;
                    break;
            }

            return ProcessLibrary.SetPriorityClass(procHandle, prioIndex);
        }
    }
}
