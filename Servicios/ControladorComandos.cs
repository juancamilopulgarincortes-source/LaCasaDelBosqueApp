using System.Windows.Forms;
using LaCasaDelBosqueApp.Modelos;

namespace LaCasaDelBosqueApp.Servicios
{
    public class ControladorComandos
    {
        private readonly Form1 form;
        private readonly Juego juego;
        private readonly GestorImagenes gestorImagenes;

        public ControladorComandos(
            Form1 form,
            Juego juego,
            GestorImagenes gestorImagenes)
        {
            this.form = form;
            this.juego = juego;
            this.gestorImagenes = gestorImagenes;
        }
        public void IrCocina()
        {
            string ubicacionAnterior = juego.Ubicacion;

            if (!juego.IrCocina())
                return;

            if (juego.LlaveTomada)
                gestorImagenes.CambiarImagen(form.Escena, "cocinasinllave.png");
            else
                gestorImagenes.CambiarImagen(form.Escena, "cocina.png");

            form.UbicacionLabel.Text = "📍 Cocina";

            form.MostrarTituloPublico("Cocina");

            if (ubicacionAnterior == "Patio")
                form.EscribirPublico("Regresas a la cocina.");
            else
                form.EscribirPublico("Llegas a la cocina.");
        }
        public void IrPatio()
        {
            string ubicacionAnterior = juego.Ubicacion;

            if (!juego.IrPatio())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "patio.png");

            form.UbicacionLabel.Text = "📍 Patio";

            form.MostrarTituloPublico("Patio");

            if (ubicacionAnterior == "Sotano")
                form.EscribirPublico("Subes la escalera y vuelves al patio.");
            else
                form.EscribirPublico("Sales por la puerta trasera hacia el patio.");
        }
    }
}