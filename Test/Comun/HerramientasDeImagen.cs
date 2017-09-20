using AForge.Imaging.Filters;
using img;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Comun
{
    public class HerramientasDeImagen
    {
        public static Bitmap CortarFragmento(Bitmap imagenCompleta, Point posicion, Size tamaño)
        {
            return ConvertirParaProcesar(imagenCompleta.Clone(new System.Drawing.Rectangle(posicion, tamaño), imagenCompleta.PixelFormat));
        }

        public static Bitmap CapturarPantalla()
        {
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                Screen.PrimaryScreen.Bounds.Y,
                                0,
                                0,
                                Screen.PrimaryScreen.Bounds.Size,
                                CopyPixelOperation.SourceCopy);

            return ConvertirParaProcesar(bmpScreenshot);
        }

        private static Bitmap ConvertirParaProcesar(Bitmap original)
        {
            Bitmap resultado = Grayscale.CommonAlgorithms.BT709.Apply(ExtBitmap.Laplacian3x3Filter(original, true));
            original.Dispose();
            resultado.Save("Convertida" + DateTime.Now.Millisecond + ".bmp");

            return resultado;
        }
    }
}
