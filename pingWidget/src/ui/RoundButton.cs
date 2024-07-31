using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pingWidget.src.ui
{
    public class RoundButton : Button
    {
        // Property to set the border radius
        public int BorderRadius { get; set; } = 10;

        public RoundButton()
        {
            // Set default properties if needed
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(100, 40); // Default size
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a path with rounded corners
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90); // Top-left corner
            path.AddArc(this.Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90); // Top-right corner
            path.AddArc(this.Width - BorderRadius, this.Height - BorderRadius, BorderRadius, BorderRadius, 0, 90); // Bottom-right corner
            path.AddArc(0, this.Height - BorderRadius, BorderRadius, BorderRadius, 90, 90); // Bottom-left corner
            path.CloseAllFigures();

            this.Region = new Region(path);

            // Draw button background
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(new SolidBrush(this.BackColor), path);

            // Draw button border
            using (Pen pen = new Pen(this.ForeColor, 2))
            {
                e.Graphics.DrawPath(pen, path);
            }

            // Draw the button text
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), ClientRectangle, sf);
        }
    }
}
