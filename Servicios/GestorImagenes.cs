using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LaCasaDelBosqueApp.Servicios
{
    public class GestorImagenes
    {
        public void CambiarImagen(PictureBox picEscena, string nombreImagen)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "imagenes",
                nombreImagen);

            if (File.Exists(ruta))
            {
                picEscena.Image?.Dispose();

                using (Image img = Image.FromFile(ruta))
                {
                    picEscena.Image = new Bitmap(img);
                }

                picEscena.SizeMode = PictureBoxSizeMode.Zoom;
                picEscena.Refresh();
            }
        }
    }
}
