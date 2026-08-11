using System.Collections.Generic;
using System.Windows.Forms;
using LaCasaDelBosqueApp.Modelos;
using LaCasaDelBosqueApp.Utilidades;

namespace LaCasaDelBosqueApp.Servicios
{
    public class GestorEventos
    {
        private readonly Form1 form;
        private readonly Juego juego;
        private readonly GestorImagenes gestorImagenes;

        public GestorEventos(
            Form1 form,
            Juego juego,
            GestorImagenes gestorImagenes)
        {
            this.form = form;
            this.juego = juego;
            this.gestorImagenes = gestorImagenes;
        }

        public void EventoRadio()
        {
            if (juego.UsarRadio())
            {
                form.IniciarEventoPublico(new List<PasoEvento>
                {
                    new PasoEvento(() =>
                    {
                        form.MostrarTituloPublico("Usar Radio");
                    }, 500),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico("*sssshhhhhhhhh*");
                    }, 1500),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico("*crrrrkkkk*");
                    }, 2000),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico(
                            "Entre la estática distingues una melodía lenta...");
                    }, 2500),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico(
                            "\"There was something I forgot to say\"");
                    }, 3500),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico(
                            "\"I was crying on Saturday night\"");
                    }, 3500),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico("*ssssshhhhhh*");
                    }, 2000),

                    new PasoEvento(() =>
                    {
                        form.EscribirPublico("");
                        form.EscribirPublico(
                            "La melodía se detiene de golpe.");
                    }, 1000)
                });
            }
            else
            {
                form.MostrarTituloPublico("Usar Radio");
                form.EscribirPublico("No tienes ninguna radio.");
            }
        }
        public void EventoArrancar()
        {
            if (juego.Ubicacion != "Auto")
            {
                form.MostrarTituloPublico("Auto");
                form.EscribirPublico("No estás dentro del automóvil.");
                return;
            }

            if (!juego.PuedeArrancar())
            {
                form.MostrarTituloPublico("Auto");
                form.EscribirPublico("El automóvil no tiene combustible.");
                form.EscribirPublico("Necesitas llenar el tanque antes de arrancarlo.");
                return;
            }

            form.IniciarEventoPublico(new List<PasoEvento>
    {
        new PasoEvento(() =>
        {
            form.MostrarTituloPublico("Auto");
            form.EscribirPublico("Introduces la llave en el contacto...");
        }, 1500),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("*Rrrrrrrr...*");
        }, 2000),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("*VRROOOOOM*");
        }, 2500),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("El motor vuelve a la vida.");
        }, 2000),

        new PasoEvento(() =>
        {
            gestorImagenes.CambiarImagen(form.Escena, "fin.png");
        }, 1500),

        new PasoEvento(() =>
        {
            form.LimpiarHistoria();

            form.EscribirPublico("");
            form.EscribirPublico("Conduces bajo la lluvia sin mirar atrás.");
            form.EscribirPublico("");
            form.EscribirPublico("La vieja casa desaparece lentamente");
            form.EscribirPublico("entre la niebla y los árboles.");
            form.EscribirPublico("");
            form.EscribirPublico("La radio se enciende sola...");
        }, 2500),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("*sssshhhhhhhhhh*");
        }, 2500),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("\"There was something I forgot to say...\"");
        }, 3000),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("\"I was crying on Saturday night...\"");
        }, 3500),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("══════════════════════════════");
            form.EscribirPublico("      LA CASA DEL BOSQUE");
            form.EscribirPublico("");
            form.EscribirPublico("          VERSIÓN 1.0");
            form.EscribirPublico("");
            form.EscribirPublico("              FIN");
            form.EscribirPublico("");
            form.EscribirPublico("      Gracias por jugar");
            form.EscribirPublico("══════════════════════════════");
        }, 4000),

        new PasoEvento(() =>
        {
            Application.Exit();
        }, 8000)
    });
        }
        public void EventoFiguraHabitacion()
        {
            form.IniciarEventoPublico(new List<PasoEvento>
    {
        new PasoEvento(() =>
        {
            form.EscribirPublico("Hay un dibujo infantil pegado a la pared.");
        }, 2000),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("Una figura oscura se asoma por la ventana.");
        }, 3000),

        new PasoEvento(() =>
        {
            form.EscribirPublico("");
            form.EscribirPublico("La cortina se cierra de golpe.");

            gestorImagenes.CambiarImagen(
                form.Escena,
                "habitacionsinsombra.png"); 

            juego.SombraVista = true;
        }, 800)
    });
        }
    }
}