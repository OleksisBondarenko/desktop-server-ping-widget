using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingWidget.src
{
    public class UIHelper
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


        public static void AdjustHeightByInnerComponents(Control control, int margin = Constants.MARGIN_BOTTOM_DEFAULT)
        {
            if (control.Controls.Count > 0)
            {
                int maxHeight = 0;
                foreach (Control item in control.Controls)
                {
                    // Calculate the bottom position of each control
                    int itemBottom = item.Top + item.Height + item.Margin.Bottom;
                    if (itemBottom > maxHeight)
                    {
                        maxHeight = itemBottom;
                    }
                }
                // Add the specified margin and adjust for control's padding and border
                int paddingBottom = control.Padding.Bottom;
                int borderHeight = control.Height - control.ClientSize.Height;
                control.Height = maxHeight + margin + paddingBottom + borderHeight;
            }
        }


        public static void AdjustControlMarginBottom(Control control, int bottom = Constants.MARGIN_BOTTOM_DEFAULT)
        {
            control.Margin = new Padding(control.Margin.Left, control.Margin.Top, control.Margin.Right, bottom);
        }

        public static void AdjustControlMargins(Control control, int left, int top, int right, int bottom)
        {
            control.Margin = new Padding(left, top, right, bottom);
        }
    }
}
