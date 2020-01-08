using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecnoAventura2018
{
    class Util
    {
        public static void ScaleFont(TextBox textbox)
        {
            float height = textbox.Height * 0.99f;
            float width = textbox.Width * 0.99f;

            textbox.SuspendLayout();

            Font tryFont = textbox.Font;
            Size tempSize = TextRenderer.MeasureText(textbox.Text, tryFont);

            float heightRatio = height / tempSize.Height;
            float widthRatio = width / tempSize.Width;

            if (!float.IsInfinity(heightRatio) && !float.IsInfinity(widthRatio))
            {
                tryFont = new Font(tryFont.FontFamily, tryFont.Size * Math.Min(widthRatio, heightRatio) - 2, tryFont.Style);

                textbox.Font = tryFont;
                //textbox.ForeColor = Color.DimGray;
            }

            textbox.ResumeLayout();
        }

        public static void ScaleFont(Label label)
        {
            float height = label.Height * 0.99f;
            float width = label.Width * 0.99f;

            label.SuspendLayout();

            Font tryFont = label.Font;
            Size tempSize = TextRenderer.MeasureText(label.Text, tryFont);

            float heightRatio = height / tempSize.Height;
            float widthRatio = width / tempSize.Width;

            if (!float.IsInfinity(heightRatio) && !float.IsInfinity(widthRatio))
            {
                tryFont = new Font(tryFont.FontFamily, tryFont.Size * Math.Min(widthRatio, heightRatio) - 2, tryFont.Style);

                label.Font = tryFont;
                //label.ForeColor = Color.DimGray;
            }

            label.ResumeLayout();
        }
    }
}
