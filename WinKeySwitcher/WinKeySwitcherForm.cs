using System.ComponentModel;
using WinKeySwitcher.Helpers;

namespace WinKeySwitcher
{
    public partial class WinKeySwitcherForm : Form
    {
        private bool _enabledLeft = false;
        private bool _enabledRight = false;

        public WinKeySwitcherForm()
        {
            InitializeComponent();

            BtnLeftKeySwitch.Configure(() => _enabledLeft, "LEFT KEY");
            BtnRightKeySwitch.Configure(() => _enabledRight, "RIGHT KEY");
            BtnBothKeySwitch.Configure(() => _enabledLeft && _enabledRight, "BOTH KEYS");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { RawInputHelper.Remove(); } catch { }
            KeyboardHook.Uninstall();
            base.OnFormClosing(e);
        }

        private void BtnLeftKeySwitchClick(object sender, EventArgs e)
        {
            _enabledLeft = !_enabledLeft;
            ApplyState();
        }

        private void BtnRightKeySwitchClick(object sender, EventArgs e)
        {
            _enabledRight = !_enabledRight;
            ApplyState();
        }

        private void BtnBothKeySwitchClick(object sender, EventArgs e)
        {
            bool turnOn = !(_enabledLeft && _enabledRight);
            _enabledLeft = turnOn;
            _enabledRight = turnOn;
            ApplyState();
        }

        private void ApplyState()
        {
            try
            {
                // Change to (_enabledLeft || _enabledRight) if we need RawInput on any toggle
                if (_enabledLeft && _enabledRight)
                    RawInputHelper.Register(Handle);
                else
                    TryRemoveRawInputSafe();

                if (_enabledLeft || _enabledRight)
                {
                    KeyboardHook.Install();
                    KeyboardHook.Configure(_enabledLeft, _enabledRight);
                }
                else
                {
                    KeyboardHook.Uninstall();
                }

                UpdateButtons();
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show($"WIN32 Error: {ex.Message}");
                KeyboardHook.Uninstall();
                TryRemoveRawInputSafe();
                _enabledLeft = _enabledRight = false;
                UpdateButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                KeyboardHook.Uninstall();
                TryRemoveRawInputSafe();
                _enabledLeft = _enabledRight = false;
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            BtnLeftKeySwitch.Invalidate();
            BtnRightKeySwitch.Invalidate();
            BtnBothKeySwitch.Invalidate();
        }

        private void TryRemoveRawInputSafe()
        {
            try { RawInputHelper.Remove(); } catch { }
            try { RawInputHelper.Remove(); } catch { }
        }
    }
}
