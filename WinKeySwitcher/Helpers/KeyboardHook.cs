using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinKeySwitcher.Helpers
{
    public static class KeyboardHook
    {
        private static nint _hookHandle = nint.Zero;
        private static NativeMethods.LowLevelKeyboardProc _proc = HookCallback;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private const int VK_LWIN = 0x5B;
        private const int VK_RWIN = 0x5C;

        private static bool _blockLeft = false;
        private static bool _blockRight = false;

        public static void Configure(bool blockLeft, bool blockRight)
        {
            _blockLeft = blockLeft;
            _blockRight = blockRight;
        }

        public static void Install()
        {
            if (_hookHandle != nint.Zero) return;

            using var curProcess = Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule!;
            _hookHandle = NativeMethods
                .SetWindowsHookEx(WH_KEYBOARD_LL, _proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);

            if (_hookHandle == nint.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public static void Uninstall()
        {
            if (_hookHandle != nint.Zero)
            {
                NativeMethods.UnhookWindowsHookEx(_hookHandle);
                _hookHandle = nint.Zero;
            }

            // reset config
            _blockLeft = false;
            _blockRight = false;
        }

        private static nint HookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0)
            {
                int vk = Marshal.ReadInt32(lParam);
                int msg = wParam.ToInt32();

                bool isKeyEvent =
                    msg == WM_KEYDOWN || msg == WM_SYSKEYDOWN ||
                    msg == WM_KEYUP || msg == WM_SYSKEYUP;

                if (isKeyEvent &&
                   (vk == VK_LWIN && _blockLeft || vk == VK_RWIN && _blockRight))
                {
                    return 1; // block
                }
            }
            return NativeMethods.CallNextHookEx(nint.Zero, nCode, wParam, lParam);
        }
    }
}
