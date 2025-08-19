using System.ComponentModel;

namespace WinKeySwitcher.CustomButton
{
    public sealed class PlayPauseButton : Button
    {
        private bool _hover;
        private Func<bool>? _isPauseProvider;
        private string _label = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CornerRadius { get; set; } = 12;

        public PlayPauseButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            FlatStyle = FlatStyle.Flat;
            UseVisualStyleBackColor = false;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            TabStop = false;
        }

        public void Configure(Func<bool> isPauseProvider, string label)
        {
            ForeColor = Color.Black;
            _isPauseProvider = isPauseProvider;
            _label = label;
            Invalidate();
        }

        protected override bool ShowFocusCues => false;

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);

            bool isPause = _isPauseProvider?.Invoke() ?? false;

            PlayPauseButtonPainter.DrawLabeledPlayPause(
                e.Graphics, ClientRectangle,
                _label,
                isPause: isPause,
                labelColor: Color.Black,
                playColor: Color.Green,
                pauseColor: Color.Red,
                font: Font,
                isHovered: _hover,
                borderThickness: 2,
                cornerRadius: CornerRadius);
        }
    }
}
