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
        public void IrSotano()
        {
            if (!juego.IrSotano())
                return;

            if (juego.CombustibleTomado)
                gestorImagenes.CambiarImagen(form.Escena, "sotano2.png");
            else
                gestorImagenes.CambiarImagen(form.Escena, "sotano1.png");

            form.UbicacionLabel.Text = "📍 Sótano";

            form.MostrarTituloPublico("Sótano");
            form.EscribirPublico("Desciendes lentamente por la vieja escalera hacia el sótano.");
        }
        public void IrBaño()
        {
            if (!juego.IrBaño())
                return;

            if (juego.RadioTomada)
                gestorImagenes.CambiarImagen(form.Escena, "banosinradio.png");
            else
                gestorImagenes.CambiarImagen(form.Escena, "bano.png");

            form.UbicacionLabel.Text = "📍 Baño";

            form.MostrarTituloPublico("Baño");
            form.EscribirPublico("Llegas al baño.");
        }
        public void IrPasillo()
        {
            if (!juego.IrPasillo())
                return;

            if (juego.PuertaHabitacionAbierta)
                gestorImagenes.CambiarImagen(form.Escena, "puertaabierta.png");
            else
                gestorImagenes.CambiarImagen(form.Escena, "pasillo.png");

            form.UbicacionLabel.Text = "📍 Pasillo";

            form.MostrarTituloPublico("Pasillo");
            form.EscribirPublico("Regresas al pasillo.");
        }
        public void Entrar()
        {
            if (!juego.Entrar())
                return;

            if (juego.PuertaHabitacionAbierta)
                gestorImagenes.CambiarImagen(form.Escena, "puertaabierta.png");
            else
                gestorImagenes.CambiarImagen(form.Escena, "pasillo.png");

            form.UbicacionLabel.Text = "📍 Pasillo";

            form.MostrarTituloPublico("Pasillo");
            form.EscribirPublico("Entras a la casa.");
        }
        public void IrEntrada()
        {
            string ubicacionAnterior = juego.Ubicacion;

            if (!juego.IrEntrada())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "entrada.png");

            form.UbicacionLabel.Text = "📍 Entrada";

            form.MostrarTituloPublico("Entrada");

            if (ubicacionAnterior == "Auto")
                form.EscribirPublico("Te alejas del automóvil y vuelves frente a la casa.");
            else
                form.EscribirPublico("Sales de la casa y vuelves a la entrada.");
        }
        public void IrAuto()
        {
            if (!juego.IrAuto())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "autolluvia.png");

            form.UbicacionLabel.Text = "📍 Auto";

            form.MostrarTituloPublico("Auto");
            form.EscribirPublico("Regresas al automóvil.");
        }
        public void IrHabitacion()
        {
            if (juego.Ubicacion != "Pasillo")
                return;

            if (!juego.IrHabitacion())
            {
                form.MostrarTituloPublico("Habitación");
                form.EscribirPublico("La puerta está cerrada. Necesitas una llave.");
                return;
            }

            if (juego.SombraVista)
                gestorImagenes.CambiarImagen(form.Escena, "habitacionsinsombra.png");
            else
                gestorImagenes.CambiarImagen(form.Escena, "habitacion.png");

            form.UbicacionLabel.Text = "📍 Habitación";

            form.MostrarTituloPublico("Habitación");
            form.EscribirPublico("Entras a la habitación.");
        }
    }
}