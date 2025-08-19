using System.Drawing.Drawing2D;

namespace WinKeySwitcher.CustomButton
{
    public static class PlayPauseButtonPainter
    {
        public static void DrawLabeledPlayPause(
            Graphics g,
            Rectangle bounds,
            string label,
            bool isPause,
            Color labelColor,
            Color playColor,
            Color pauseColor,
            Font font,
            bool isHovered = false,
            Color? baseBackColor = null,
            Color? hoverBackColor = null,
            Color? baseBorderColor = null,
            Color? hoverBorderColor = null,
            Color? hoverLabelColor = null,
            int borderThickness = 2,
            int cornerRadius = 8)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var backCol = baseBackColor ?? SystemColors.Control;
            var borderCol = baseBorderColor ?? Color.DarkGray;
            var textCol = labelColor;

            var hovBack = hoverBackColor ?? ControlPaint.Light(backCol, 0.15f);
            var hovBorder = hoverBorderColor ?? ControlPaint.Dark(borderCol, 0.10f);
            var hovText = hoverLabelColor ?? labelColor;

            if (isHovered)
            {
                backCol = hovBack;
                borderCol = hovBorder;
                textCol = hovText;
            }

            var inset = borderThickness / 2f;
            var boundsF = new RectangleF(
                bounds.X + inset,
                bounds.Y + inset,
                bounds.Width - borderThickness,
                bounds.Height - borderThickness);

            using var path = CreateRoundedRectanglePath(boundsF, cornerRadius);
            using (var bg = new SolidBrush(backCol))
                g.FillPath(bg, path);

            var labelSize = TextRenderer.MeasureText(g, label, font, bounds.Size, TextFormatFlags.NoPadding);
            var gap = 8;
            var iconBox = Math.Max(18, (int)(labelSize.Height * 0.9));

            var totalW = labelSize.Width + gap + iconBox;
            var labelX = (bounds.Width - totalW) / 2;
            var labelY = (bounds.Height - labelSize.Height) / 2;

            TextRenderer.DrawText(g, label, font,
                new Rectangle(labelX, labelY, labelSize.Width, labelSize.Height),
                textCol, TextFormatFlags.NoPadding);

            var iconRect = new Rectangle(
                labelX + labelSize.Width + gap,
                (bounds.Height - iconBox) / 2,
                iconBox, iconBox);

            if (isPause)
                DrawPause(g, iconRect, pauseColor);
            else
                DrawPlay(g, iconRect, playColor);

            using var pen = new Pen(borderCol, borderThickness) { Alignment = PenAlignment.Inset };
            g.DrawPath(pen, path);
        }

        private static GraphicsPath CreateRoundedRectanglePath(RectangleF rect, int radius)
        {
            var r = Math.Max(0, radius);
            var d = r * 2f;
            var path = new GraphicsPath();

            if (r <= 0f)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static void DrawPlay(Graphics g, Rectangle box, Color color)
        {
            using var b = new SolidBrush(color);
            var margin = Math.Max(2, box.Width / 10);
            var left = box.Left + margin;
            var right = box.Right - margin;
            var top = box.Top + margin;
            var bottom = box.Bottom - margin;
            var midY = (top + bottom) / 2;

            var pts = new[]
            {
                new Point(left, top),
                new Point(right, midY),
                new Point(left, bottom)
            };
            g.FillPolygon(b, pts);
        }

        private static void DrawPause(Graphics g, Rectangle box, Color color)
        {
            using var b = new SolidBrush(color);
            var margin = Math.Max(2, box.Width / 10);
            var barW = Math.Max(3, box.Width / 5);
            var gapBars = Math.Max(2, barW / 2) + 3;
            var innerH = box.Height - 2 * margin;

            var x1 = box.Left + margin;
            var x2 = x1 + barW + gapBars;

            var bar1 = new Rectangle(x1, box.Top + margin, barW, innerH);
            var bar2 = new Rectangle(x2, box.Top + margin, barW, innerH);

            g.FillRectangle(b, bar1);
            g.FillRectangle(b, bar2);
        }
    }
}
