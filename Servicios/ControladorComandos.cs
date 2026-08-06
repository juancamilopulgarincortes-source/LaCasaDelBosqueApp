using LaCasaDelBosqueApp.Modelos;
using LaCasaDelBosqueApp.Utilidades;
using System.Collections.Generic;
using System.Windows.Forms;

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
        // ====================
        // MOVIMIENTOS
        // ====================
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
        // ====================
        // OBJETOS
        // ====================
        public void TomarLlave()
        {
            if (!juego.TomarLlave())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "cocinasinllave.png");

            form.MostrarTituloPublico("Tomar Llave");
            form.EscribirPublico("Has tomado la llave.");
        }
        public void TomarRadio()
        {
            if (!juego.TomarRadio())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "banosinradio.png");

            form.MostrarTituloPublico("Tomar Radio");
            form.EscribirPublico("Has tomado la radio.");
        }
        public void TomarCombustible()
        {
            if (!juego.TomarCombustible())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "sotano2.png");

            form.MostrarTituloPublico("Tomar Combustible");
            form.EscribirPublico("Has tomado el bidón de combustible.");
        }
        // ====================
        // ACCIONES
        // ====================
        public void UsarLlave()
        {
            if (!juego.UsarLlave())
                return;

            gestorImagenes.CambiarImagen(form.Escena, "puertaabierta.png");

            form.MostrarTituloPublico("Usar Llave");
            form.EscribirPublico("Usas la llave.");
            form.EscribirPublico("La puerta de la habitación se abre.");
        }
        public void UsarCombustible()
        {
            if (!juego.UsarCombustible())
            {
                form.MostrarTituloPublico("Auto");
                form.EscribirPublico("No puedes hacer eso ahora.");
                return;
            }

            form.MostrarTituloPublico("Usar Combustible");
            form.EscribirPublico("Vacías el bidón en el tanque.");
            form.EscribirPublico("Ahora el automóvil tiene suficiente combustible.");
            form.EscribirPublico("Quizá ahora puedas arrancar el motor.");
        }
        public void UsarRadio()
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
                form.EscribirPublico("Entre la estática distingues una melodía lenta...");
            }, 2500),

            new PasoEvento(() =>
            {
                form.EscribirPublico("");
                form.EscribirPublico("\"There was something I forgot to say\"");
            }, 3500),

            new PasoEvento(() =>
            {
                form.EscribirPublico("");
                form.EscribirPublico("\"I was crying on Saturday night\"");
            }, 3500),

            new PasoEvento(() =>
            {
                form.EscribirPublico("");
                form.EscribirPublico("*ssssshhhhhh*");
            }, 2000),

            new PasoEvento(() =>
            {
                form.EscribirPublico("");
                form.EscribirPublico("La melodía se detiene de golpe.");
            }, 1000)
        });
            }
            else
            {
                form.MostrarTituloPublico("Usar Radio");
                form.EscribirPublico("No tienes ninguna radio.");
            }
        }

        public void Arrancar()
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

        public void Examinar()
        {
            switch (juego.Ubicacion)
            {
                case "Entrada":
                    form.MostrarTituloPublico("Examinar");
                    form.EscribirPublico("La puerta está entreabierta.");
                    form.EscribirPublico("Una corriente fría sale del interior.");
                    break;

                case "Auto":
                    form.MostrarTituloPublico("Examinar");
                    form.EscribirPublico("La gasolina apenas alcanzaría para unos pocos kilómetros.");
                    form.EscribirPublico("Por alguna razón, marcharte ahora no parece una opción.");
                    break;

                case "Pasillo":
                    form.MostrarTituloPublico("Examinar");
                    form.EscribirPublico("El papel tapiz está deteriorado.");
                    break;

                case "Baño":
                    form.MostrarTituloPublico("Examinar");

                    if (!juego.RadioTomada)
                        form.EscribirPublico("Hay una radio vieja sobre el lavabo.");
                    else
                        form.EscribirPublico("El lavabo está vacío.");

                    break;

                case "Cocina":
                    form.MostrarTituloPublico("Examinar");

                    if (!juego.LlaveTomada)
                        form.EscribirPublico("Hay una llave oxidada sobre la mesa.");
                    else
                        form.EscribirPublico("La mesa está vacía. Solo quedan marcas en el polvo donde antes había algo.");

                    break;
                case "Patio":
                    form.MostrarTituloPublico("Examinar");
                    form.EscribirPublico("La lluvia ha convertido la tierra en barro.");
                    form.EscribirPublico("La maleza cubre casi todo el patio.");
                    form.EscribirPublico("Entre la hierba descubres una vieja escotilla de madera.");
                    form.EscribirPublico("Parece conducir al sótano.");
                    break;

                case "Sotano":
                    form.MostrarTituloPublico("Examinar");

                    if (!juego.CombustibleTomado)
                    {
                        form.EscribirPublico("El sótano huele intensamente a gasolina.");
                        form.EscribirPublico("Junto a la pared hay un viejo bidón de combustible.");
                    }
                    else
                    {
                        form.EscribirPublico("El lugar está completamente vacío.");
                        form.EscribirPublico("Solo queda una marca húmeda donde estaba el bidón.");
                    }

                    break;

                case "Habitacion":
                    form.MostrarTituloPublico("Examinar");

                    if (!juego.SombraVista)
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

                gestorImagenes.CambiarImagen(form.Escena, "habitacionsinsombra.png");
                juego.SombraVista = true;
            }, 800)
        });
                    }
                    else
                    {
                        form.EscribirPublico("La figura oscura ya no está.");
                    }

                    break;
            }
        }
        public void MostrarInventario()
        {
            form.MostrarCabeceraPublica("Inventario");

            if (juego.Inventario.Count == 0)
            {
                form.EscribirPublico("Inventario vacío.");
                return;
            }

            foreach (string item in juego.Inventario)
            {
                form.EscribirPublico("• " + item);
            }
        }
        public void MostrarAyuda()
        {
            form.MostrarCabeceraPublica("Comandos");

            form.EscribirPublico("Movimiento:");
            form.EscribirPublico("• entrar");
            form.EscribirPublico("• ir baño");
            form.EscribirPublico("• ir cocina");
            form.EscribirPublico("• ir patio");
            form.EscribirPublico("• ir sotano");
            form.EscribirPublico("• ir habitacion");
            form.EscribirPublico("• ir pasillo");
            form.EscribirPublico("• ir entrada");
            form.EscribirPublico("• ir auto");

            form.EscribirPublico("");

            form.EscribirPublico("Interacción:");
            form.EscribirPublico("• examinar");
            form.EscribirPublico("• tomar llave");
            form.EscribirPublico("• usar llave");
            form.EscribirPublico("• tomar radio");
            form.EscribirPublico("• usar radio");
            form.EscribirPublico("• tomar combustible");
            form.EscribirPublico("• usar combustible");

            form.EscribirPublico("");

            form.EscribirPublico("Información:");
            form.EscribirPublico("• inventario");
            form.EscribirPublico("• ayuda");
        }
        // ====================
        // PROCESADOR DE COMANDOS
        // ====================
        public void Ejecutar(string comando)
        {
            switch (comando)
            {
                case "entrar":
                    Entrar();
                    break;

                case "ir entrada":
                    IrEntrada();
                    break;

                case "ir auto":
                    IrAuto();
                    break;

                case "ir baño":
                    IrBaño();
                    break;

                case "ir cocina":
                    IrCocina();
                    break;

                case "ir patio":
                    IrPatio();
                    break;

                case "ir sotano":
                    IrSotano();
                    break;

                case "ir pasillo":
                    IrPasillo();
                    break;

                case "ir habitacion":
                    IrHabitacion();
                    break;

                case "tomar llave":
                    TomarLlave();
                    break;

                case "tomar radio":
                    TomarRadio();
                    break;

                case "tomar combustible":
                    TomarCombustible();
                    break;

                case "usar llave":
                    UsarLlave();
                    break;

                case "usar combustible":
                    UsarCombustible();
                    break;

                case "usar radio":
                    UsarRadio();
                    break;

                case "arrancar":
                    Arrancar();
                    break;

                case "examinar":
                    Examinar();
                    break;

                case "inventario":
                    MostrarInventario();
                    break;

                case "ayuda":
                    MostrarAyuda();
                    break;

                default:
                    MessageBox.Show(
                        "No entiendo ese comando.",
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
        }
    }
}