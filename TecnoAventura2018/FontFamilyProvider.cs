using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoAventura2018
{
    class FontFamilyProvider
    {
        private static FontFamilyProvider instance = null;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        private FontFamily customFontFamily;

        private FontFamilyProvider()
        {
            // custom font
            byte[] fontData = Properties.Resources.MF_TEXAS_SPRING;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.MF_TEXAS_SPRING.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.MF_TEXAS_SPRING.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            customFontFamily = fonts.Families[0];
        }

        public static FontFamilyProvider GetInstance()
        {
            if (instance == null)
            {
                instance = new FontFamilyProvider();
            }
            return instance;
        }

        // custom font
        public static Font GetCustomFont(float fontSize)
        {
            return new Font(GetInstance().customFontFamily, fontSize);
        }
    }
}
