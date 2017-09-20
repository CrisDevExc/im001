namespace img
{
    using AForge.Imaging;
    using AForge.Imaging.Filters;
    using Comun;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Text;

    public class Procesador
    {
        #region Variables privadas
        #endregion

        #region Constructores
        #endregion

        #region Propiedades privadas
        #endregion

        #region Propiedades protegidas
        #endregion

        #region Propiedades públicas
        #endregion

        #region Métodos privados
        #endregion

        #region Métodos protegidos
        #endregion

        #region Métodos públicos
        private Bitmap ConvertirParaProcesar(Bitmap original)
        {
            //Bitmap clone = new Bitmap(original.Width, original.Height,System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //using (Graphics gr = Graphics.FromImage(clone))
            //{
            //    gr.DrawImage(original, new Rectangle(0, 0, clone.Width, clone.Height));
            //}

            //original.Dispose();

            //return Grayscale.CommonAlgorithms.BT709.Apply(original);
            //Bitmap imagenEscalaDeGrises = Grayscale.CommonAlgorithms.BT709.Apply(original);
            //ResizeBilinear filter = new ResizeBilinear(1024, 768);
            //// apply the filter
            //Bitmap newImage = filter.Apply(original);
            //const float limit = 0.3f;
            //for (int i = 0; i < original.Width; i++)
            //{
            //    for (int j = 0; j < original.Height; j++)
            //    {
            //        Color c = original.GetPixel(i, j);
            //        if (c.GetBrightness() > limit)
            //        {
            //            original.SetPixel(i, j, Color.White);
            //        }
            //    }
            //}

            Bitmap resultado = Grayscale.CommonAlgorithms.BT709.Apply(ExtBitmap.Laplacian3x3Filter(original, true));
                resultado.Save("Convertida" + DateTime.Now.Millisecond + ".bmp");
            original.Dispose();
            return resultado;

            //return clone;
        }

        public void Procesar()
        {
            System.Drawing.Bitmap sourceImage = this.ConvertirParaProcesar((Bitmap)Bitmap.FromFile(@"C:\Users\clatour\Documents\Visual Studio 2015\Projects\img\img\PantallaCompleta.bmp"));
            System.Drawing.Bitmap template = this.ConvertirParaProcesar((Bitmap)Bitmap.FromFile(@"C:\Users\clatour\Documents\Visual Studio 2015\Projects\img\img\Fragmento.bmp"));

            // create template matching algorithm's instance
            // (set similarity threshold to 92.5%)

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.99f);
            // find all matchings with specified above similarity
            TemplateMatch[] matchings = null;

            while (matchings == null || matchings.Count() == 0)
            {
                tm.SimilarityThreshold -= 0.01f;
                matchings = tm.ProcessImage(sourceImage, template);
                if (matchings.Count() > 0 || tm.SimilarityThreshold < 0.8f)
                {
                    break;
                }
            }

            TemplateMatch mejorCoincidencia = matchings.ToList().First(x => matchings.ToList().Max(m => m.Similarity) == x.Similarity);

            Bitmap res = (Bitmap)Bitmap.FromFile(@"C:\Users\clatour\Documents\Visual Studio 2015\Projects\img\img\PantallaCompleta.bmp");
            Graphics g = Graphics.FromImage(res);
            Pen pen = new Pen(Color.White, 2);

            foreach (var item in matchings)
            {

                g.DrawRectangle(pen, item.Rectangle);
            }

            g.Flush();
            res.Save("resultado.bmp");
            res.Dispose();
            sourceImage.Dispose();
            template.Dispose();
            g.Dispose();
        }
        #endregion
    }
}
