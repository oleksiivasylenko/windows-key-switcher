using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WinKeySwitcher.Helpers
{
    public static class RawInputHelper
    {
        public static void Register(nint hwnd)
        {
            var rid = new NativeMethods.RAWINPUTDEVICE
            {
                usUsagePage = 0x01,
                usUsage = 0x06, // Keyboard
                dwFlags = NativeMethods.RawInputDeviceFlags.RIDEV_NOHOTKEYS | NativeMethods.RawInputDeviceFlags.RIDEV_INPUTSINK,
                hwndTarget = hwnd
            };

            if (!NativeMethods.RegisterRawInputDevices([rid], 1, (uint)Marshal.SizeOf<NativeMethods.RAWINPUTDEVICE>()))
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public static void Remove()
        {
            var rid = new NativeMethods.RAWINPUTDEVICE
            {
                usUsagePage = 0x01,
                usUsage = 0x06,
                dwFlags = NativeMethods.RawInputDeviceFlags.RIDEV_REMOVE,
                hwndTarget = nint.Zero // MUST be zero on REMOVE
            };

            if (!NativeMethods.RegisterRawInputDevices([rid], 1, (uint)Marshal.SizeOf<NativeMethods.RAWINPUTDEVICE>()))
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}
