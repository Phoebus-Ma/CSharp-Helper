using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ProcessAffinity
{
    internal class ProcessLibrary
    {
        /* Process access. */
        public readonly static uint PROCESS_TERMINATE           = 0x0001;
        public readonly static uint PROCESS_CREATE_THREAD       = 0x0002;
        public readonly static uint PROCESS_SET_SESSIONID       = 0x0004;
        public readonly static uint PROCESS_VM_OPERATION        = 0x0008;
        public readonly static uint PROCESS_VM_READ             = 0x0010;
        public readonly static uint PROCESS_VM_WRITE            = 0x0020;
        public readonly static uint PROCESS_DUP_HANDLE          = 0x0040;
        public readonly static uint PROCESS_CREATE_PROCESS      = 0x0080;
        public readonly static uint PROCESS_SET_QUOTA           = 0x0100;
        public readonly static uint PROCESS_SET_INFORMATION     = 0x0200;
        public readonly static uint PROCESS_QUERY_INFORMATION   = 0x0400;
        public readonly static uint PROCESS_SUSPEND_RESUME      = 0x0800;
        public readonly static uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        public readonly static uint PROCESS_SET_LIMITED_INFORMATION = 0x2000;

        /* Process priority. */
        public readonly static uint NORMAL_PRIORITY_CLASS       = 0x00000020;
        public readonly static uint IDLE_PRIORITY_CLASS         = 0x00000040;
        public readonly static uint HIGH_PRIORITY_CLASS         = 0x00000080;
        public readonly static uint REALTIME_PRIORITY_CLASS     = 0x00000100;
        public readonly static uint BELOW_NORMAL_PRIORITY_CLASS = 0x00004000;
        public readonly static uint ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000;
        public readonly static uint PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000;
        public readonly static uint PROCESS_MODE_BACKGROUND_END = 0x00200000;

        /* Opens an existing local process object. */
        [DllImport("kernel32.dll")]
        public static extern IntPtr
        OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        /* Closes an open object handle. */
        [DllImport("kernel32.dll")]
        private static extern bool
        CloseHandle(IntPtr hObject);

        /* Set Process Affinity CPU Mask. */
        [DllImport("kernel32.dll")]
        public static extern bool
        SetProcessAffinityMask(IntPtr hProcess, UIntPtr dwProcessAffinityMask);

        /* Get Process Affinity CPU Mask. */
        [DllImport("kernel32.dll")]
        public static extern IntPtr
        GetProcessAffinityMask(IntPtr hProcess, UIntPtr lpProcessAffinityMask, UIntPtr lpSystemAffinityMask);

        /* Set Process Priority. */
        [DllImport("kernel32.dll")]
        public static extern bool
        SetPriorityClass(IntPtr hProcess, uint dwPriorityClass);

        /* Get Process Priority. */
        [DllImport("kernel32.dll")]
        public static extern uint
        GetPriorityClass(IntPtr hProcess);
    }
}
