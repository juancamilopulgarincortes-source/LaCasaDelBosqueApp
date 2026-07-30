using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using LaCasaDelBosqueApp.Modelos;
using LaCasaDelBosqueApp.Servicios;
using LaCasaDelBosqueApp.Utilidades;

namespace LaCasaDelBosqueApp

{
    public partial class Form1 : Form
    {

        Juego juego = new Juego();
        GestorImagenes gestorImagenes;

        private System.Windows.Forms.Timer timerIntro = new System.Windows.Forms.Timer();
        private int pasoIntro = 0;

        private System.Windows.Forms.Timer timerEvento = new System.Windows.Forms.Timer();
        private List<PasoEvento> pasosEvento = new List<PasoEvento>();
        private int pasoEvento = 0;

        public Form1()
        {
            InitializeComponent();

            gestorImagenes = new GestorImagenes();
            this.AcceptButton = btnEnviar;
            this.Shown += (s, e) =>
            {
                txtComando.Focus();
                this.ActiveControl = txtComando;
                label1.Visible = false;
                lblUbicacion.Visible = false;
                Introduccion();
            };

        }

        private void Introduccion()
        {
            txtComando.Enabled = false;
            btnEnviar.Enabled = false;

            rtbHistoria.Clear();

            gestorImagenes.CambiarImagen(picEscena, "autolluvia.png");

            pasoIntro = 0;

            timerIntro.Interval = 2000;
            timerIntro.Tick -= TimerIntro_Tick;
            timerIntro.Tick += TimerIntro_Tick;
            timerIntro.Start();
        }

        private void IniciarEvento(List<PasoEvento> pasos)
        {
            txtComando.Enabled = false;
            btnEnviar.Enabled = false;

            pasosEvento = pasos;
            pasoEvento = 0;

            timerEvento.Stop();

            timerEvento.Tick -= TimerEvento_Tick;
            timerEvento.Tick += TimerEvento_Tick;

            timerEvento.Interval = pasosEvento[0].Espera;
            timerEvento.Start();
        }

        private void TimerEvento_Tick(object sender, EventArgs e)
        {
            if (pasoEvento < pasosEvento.Count)
            {
                pasosEvento[pasoEvento].Accion();

                pasoEvento++;

                if (pasoEvento < pasosEvento.Count)
                {
                    timerEvento.Interval = pasosEvento[pasoEvento].Espera;
                }
            }
            else
            {
                timerEvento.Stop();

                txtComando.Enabled = true;
                btnEnviar.Enabled = true;
                txtComando.Focus();
            }
        }
        private void TimerIntro_Tick(object sender, EventArgs e)
        {
            switch (pasoIntro)
            {
                case 0:
                    Escribir("");
                    Escribir("La lluvia golpea el parabrisas.");
                    break;

                case 1:
                    Escribir("");
                    Escribir("La gasolina se esta agotando.");
                    break;

                case 2:
                    Escribir("");
                    Escribir("Veo una vieja casa.");
                    break;

                case 3:
                    Escribir("");
                    Escribir("Apagas el motor.");
                    break;

                case 4:
                    Escribir("");
                    Escribir("Bajas del automóvil...");
                    break;

                case 5:
                    gestorImagenes.CambiarImagen(picEscena, "entrada.png");
                    break;

                case 6:
                    label1.Visible = true;
                    break;

                case 7:
                    lblUbicacion.Visible = true;
                    lblUbicacion.Text = "📍 Entrada";

                    juego.Ubicacion = "Entrada";

                    Escribir("");
                    Escribir("Escribe 'ayuda' para ver los comandos.");

                    txtComando.Enabled = true;
                    btnEnviar.Enabled = true;
                    txtComando.Focus();

                    timerIntro.Stop();
                    break;
            }

            pasoIntro++;
        }

        private void Escribir(string texto)
        {
            rtbHistoria.AppendText(texto + Environment.NewLine);
            rtbHistoria.SelectionStart = rtbHistoria.Text.Length;
            rtbHistoria.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comando = txtComando.Text.Trim().ToLower();

            txtComando.Clear();

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

                case "tomar radio":
                    TomarRadio();
                    break;

                case "usar radio":
                    UsarRadio();
                    break;

                case "examinar":
                    Examinar();
                    break;

                case "tomar llave":
                    TomarLlave();
                    break; ;

                case "usar llave":
                    UsarLlave();
                    break;

                case "tomar combustible":
                    TomarCombustible();
                    break;

                case "usar combustible":
                    UsarCombustible();
                    break;

                case "arrancar":
                    Arrancar();
                    break;

                case "inventario":
                    MostrarInventario();
                    break;

                case "ayuda":
                    MostrarAyuda();
                    break;

                default:

                    Escribir("");
                    Escribir("[ ERROR ]");
                    Escribir("No entiendo ese comando.");

                    MessageBox.Show(
                    "No entiendo ese comando.",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    break;
            }
        }

        private void IrCocina()
        {
            string ubicacionAnterior = juego.Ubicacion;

            if (!juego.IrCocina())
                return;

            if (juego.LlaveTomada)
                gestorImagenes.CambiarImagen(picEscena, "cocinasinllave.png");
            else
                gestorImagenes.CambiarImagen(picEscena, "cocina.png");

            lblUbicacion.Text = "📍 Cocina";

            Escribir("");
            Escribir("[ COCINA ]");

            if (ubicacionAnterior == "Patio")
                Escribir("Regresas a la cocina.");
            else
                Escribir("Llegas a la cocina.");
        }

        private void IrPatio()
        {
            string ubicacionAnterior = juego.Ubicacion;

            if (!juego.IrPatio())
                return;

            gestorImagenes.CambiarImagen(picEscena, "patio.png");

            lblUbicacion.Text = "📍 Patio";

            Escribir("");
            Escribir("[ PATIO ]");

            if (ubicacionAnterior == "Sotano")
                Escribir("Subes la escalera y vuelves al patio.");
            else
                Escribir("Sales por la puerta trasera hacia el patio.");
        }

        private void IrSotano()
        {
            if (!juego.IrSotano())
                return;

            if (juego.CombustibleTomado)
                gestorImagenes.CambiarImagen(picEscena, "sotano2.png");
            else
                gestorImagenes.CambiarImagen(picEscena, "sotano1.png");

            lblUbicacion.Text = "📍 Sótano";

            Escribir("");
            Escribir("[ SÓTANO ]");
            Escribir("Desciendes lentamente por la vieja escalera hacia el sótano.");
        }   

        private void IrPasillo()
        {
            if (!juego.IrPasillo())
                return;

            if (juego.PuertaHabitacionAbierta)
                gestorImagenes.CambiarImagen(picEscena, "puertaabierta.png");
            else
                gestorImagenes.CambiarImagen(picEscena, "pasillo.png");

            lblUbicacion.Text = "📍 Pasillo";

            Escribir("");
            Escribir("[ PASILLO ]");
            Escribir("Regresas al pasillo.");
        }

        private void IrBaño()
        {
            if (!juego.IrBaño())
                return;

            if (juego.RadioTomada)
                gestorImagenes.CambiarImagen(picEscena, "banosinradio.png");
            else
                gestorImagenes.CambiarImagen(picEscena, "bano.png");

            lblUbicacion.Text = "📍 Baño";

            Escribir("");
            Escribir("[ BAÑO ]");
            Escribir("Llegas al baño.");
        }

        private void IrHabitacion()
        {
            if (juego.Ubicacion != "Pasillo")
                return;

            if (!juego.IrHabitacion())
            {
                Escribir("");
                Escribir("[ HABITACION ]");
                Escribir("La puerta está cerrada. Necesitas una llave.");
                return;
            }

            if (juego.SombraVista)
                gestorImagenes.CambiarImagen(picEscena, "habitacionsinsombra.png");
            else
                gestorImagenes.CambiarImagen(picEscena, "habitacion.png");

            lblUbicacion.Text = "📍 Habitacion";

            Escribir("");
            Escribir("[ HABITACION ]");
            Escribir("Entras a la habitación.");
        }

        private void IrEntrada()
        {
            string ubicacionAnterior = juego.Ubicacion;

            if (!juego.IrEntrada())
                return;

            gestorImagenes.CambiarImagen(picEscena, "entrada.png");
            lblUbicacion.Text = "📍 Entrada";

            Escribir("");
            Escribir("[ ENTRADA ]");

            if (ubicacionAnterior == "Auto")
                Escribir("Te alejas del automóvil y vuelves frente a la casa.");
            else
                Escribir("Sales de la casa y vuelves a la entrada.");
        }

        private void IrAuto()
        {
            if (!juego.IrAuto())
                return;

            gestorImagenes.CambiarImagen(picEscena, "autolluvia.png");

            lblUbicacion.Text = "📍 Auto";

            Escribir("");
            Escribir("[ AUTO ]");
            Escribir("Regresas al automóvil.");
        }

        private void Entrar()
        {
            if (!juego.Entrar())
                return;

            if (juego.PuertaHabitacionAbierta)
                gestorImagenes.CambiarImagen(picEscena, "puertaabierta.png");
            else
                gestorImagenes.CambiarImagen(picEscena, "pasillo.png");

            lblUbicacion.Text = "📍 Pasillo";

            Escribir("");
            Escribir("[ PASILLO ]");
            Escribir("Entras a la casa.");
        }

        private void TomarLlave()
        {
            if (juego.Ubicacion == "Cocina" &&
                !juego.Inventario.Contains("llave"))
            {
                juego.Inventario.Add("llave");
                juego.LlaveTomada = true;

                gestorImagenes.CambiarImagen(picEscena, "cocinasinllave.png");

                Escribir("");
                Escribir("[ TOMAR LLAVE ]");
                Escribir("Has tomado la llave.");
            }
        }

        private void TomarRadio()
        {
            if (juego.Ubicacion == "Baño" &&
                !juego.Inventario.Contains("radio"))
            {
                juego.Inventario.Add("radio");
                juego.RadioTomada = true;

                gestorImagenes.CambiarImagen(picEscena, "banosinradio.png");

                Escribir("");
                Escribir("[ TOMAR RADIO ]");
                Escribir("Has tomado la radio.");
            }
        }

        private void TomarCombustible()
        {
            if (juego.Ubicacion == "Sotano" &&
                !juego.Inventario.Contains("combustible"))
            {
                juego.Inventario.Add("combustible");
                juego.CombustibleTomado = true;

                gestorImagenes.CambiarImagen(picEscena, "sotano2.png");

                Escribir("");
                Escribir("[ TOMAR COMBUSTIBLE ]");
                Escribir("Has tomado el bidón de combustible.");
            }
        }

        private void UsarLlave()
        {
            if (juego.Ubicacion == "Pasillo" &&
                juego.Inventario.Contains("llave") &&
                !juego.PuertaHabitacionAbierta)
            {
                juego.Inventario.Remove("llave");

                juego.PuertaHabitacionAbierta = true;

                gestorImagenes.CambiarImagen(picEscena, "puertaabierta.png");

                Escribir("");
                Escribir("[ USAR LLAVE ]");
                Escribir("Usas la llave.");
                Escribir("La puerta de la habitación se abre.");
            }
        }

        private void UsarCombustible()
        {
            if (juego.Ubicacion == "Auto" &&
                juego.Inventario.Contains("combustible"))
            {
                juego.Inventario.Remove("combustible");
                juego.AutoConCombustible = true;

                Escribir("");
                Escribir("[ USAR COMBUSTIBLE ]");
                Escribir("Vacías el bidón en el tanque.");
                Escribir("Ahora el automóvil tiene suficiente combustible.");
                Escribir("Quizá ahora puedas arrancar el motor.");
            }
            else
            {
                Escribir("");
                Escribir("[ AUTO ]");
                Escribir("No puedes hacer eso ahora.");
            }
        }

        private void UsarRadio()
        {
            if (juego.Inventario.Contains("radio"))
            {
                IniciarEvento(new List<PasoEvento>
        {
            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("[ USAR RADIO ]");
            }, 500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("*sssshhhhhhhhh*");
            }, 1500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("*crrrrkkkk*");
            }, 2000),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("Entre la estática distingues una melodía lenta...");
            }, 2500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("\"There was something I forgot to say\"");
            }, 3500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("\"I was crying on Saturday night\"");
            }, 3500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("*ssssshhhhhh*");
            }, 2000),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("La melodía se detiene de golpe.");
            }, 1000)
        });
            }
            else
            {
                Escribir("");
                Escribir("[ USAR RADIO ]");
                Escribir("No tienes ninguna radio.");
            }
        }

        private void Arrancar()
        {
            if (juego.Ubicacion != "Auto")
            {
                Escribir("");
                Escribir("[ AUTO ]");
                Escribir("No estás dentro del automóvil.");
            }
            else if (!juego.AutoConCombustible)
            {
                Escribir("");
                Escribir("[ AUTO ]");
                Escribir("El automóvil no tiene combustible.");
                Escribir("Necesitas llenar el tanque antes de arrancarlo.");
            }
            else
            {
                IniciarEvento(new List<PasoEvento>
        {
            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("[ AUTO ]");
                Escribir("Introduces la llave en el contacto...");
            }, 1500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("*Rrrrrrrr...*");
            }, 2000),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("*VRROOOOOM*");
            }, 2500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("El motor vuelve a la vida.");
            }, 2000),

            new PasoEvento(() =>
            {
                gestorImagenes.CambiarImagen(picEscena, "fin.png");
            }, 1500),

            new PasoEvento(() =>
            {
                rtbHistoria.Clear();

                Escribir("");
                Escribir("Conduces bajo la lluvia sin mirar atrás.");
                Escribir("");
                Escribir("La vieja casa desaparece lentamente");
                Escribir("entre la niebla y los árboles.");
                Escribir("");
                Escribir("La radio se enciende sola...");
            }, 2500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("*sssshhhhhhhhhh*");
            }, 2500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("\"There was something I forgot to say...\"");
            }, 3000),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("\"I was crying on Saturday night...\"");
            }, 3500),

            new PasoEvento(() =>
            {
                Escribir("");
                Escribir("══════════════════════════════");
                Escribir("      LA CASA DEL BOSQUE");
                Escribir("");
                Escribir("          VERSIÓN 1.0");
                Escribir("");
                Escribir("              FIN");
                Escribir("");
                Escribir("      Gracias por jugar");
                Escribir("══════════════════════════════");
            }, 4000),

            new PasoEvento(() =>
            {
                Application.Exit();
            }, 8000)
        });
            }
        }

        private void Examinar()
        {
            switch (juego.Ubicacion)
            {
                case "Entrada":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");
                    Escribir("La puerta está entreabierta.");
                    Escribir("Una corriente fría sale del interior.");

                    break;

                case "Auto":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");
                    Escribir("La gasolina apenas alcanzaría para unos pocos kilómetros.");
                    Escribir("Por alguna razón, marcharte ahora no parece una opción.");
                    break;

                case "Pasillo":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");
                    Escribir("El papel tapiz está deteriorado.");

                    break;

                case "Baño":

                    Escribir("");
                    Escribir("[ EXAMINAR ]");
                    if (!juego.RadioTomada)
                        Escribir("Hay una radio vieja sobre el lavabo.");
                    else
                        Escribir("El lavabo está vacío.");

                    break;

                case "Cocina":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");

                    if (!juego.LlaveTomada)
                        Escribir("Hay una llave oxidada sobre la mesa.");
                    else
                        Escribir("La mesa está vacía. Solo quedan marcas en el polvo donde antes había algo.");

                    break;

                case "Patio":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");
                    Escribir("La lluvia ha convertido la tierra en barro.");
                    Escribir("La maleza cubre casi todo el patio.");
                    Escribir("Entre la hierba descubres una vieja escotilla de madera.");
                    Escribir("Parece conducir al sótano.");
                    break;

                case "Sotano":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");

                    if (!juego.CombustibleTomado)
                    {
                        Escribir("El sótano huele intensamente a gasolina.");
                        Escribir("Junto a la pared hay un viejo bidón de combustible.");
                    }
                    else
                    {
                        Escribir("El lugar está completamente vacío.");
                        Escribir("Solo queda una marca húmeda donde estaba el bidón.");
                    }

                    break;

                case "Habitacion":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");

                    if (!juego.SombraVista)
                    {
                        IniciarEvento(new List<PasoEvento>
    {
        new PasoEvento(() =>
        {
            Escribir("Hay un dibujo infantil pegado a la pared.");
        }, 2000),

        new PasoEvento(() =>
        {
            Escribir("");
            Escribir("Una figura oscura se asoma por la ventana.");
        }, 3000),

        new PasoEvento(() =>
        {
            Escribir("");
            Escribir("La cortina se cierra de golpe.");

            gestorImagenes.CambiarImagen(picEscena, "habitacionsinsombra.png");
            juego.SombraVista = true;
        }, 800)
    });
                    }
                    else
                    {
                        Escribir("La figura oscura ya no está.");
                    }

                    break;
            }
        }
        private void MostrarInventario()
        {
            Escribir("");

            if (juego.Inventario.Count == 0)
            {
                Escribir("");
                Escribir("═════════════════════════════");
                Escribir("INVENTARIO");
                Escribir("═════════════════════════════");
                Escribir("Inventario vacío.");
                return;
            }

            Escribir("");
            Escribir("═════════════════════════════");
            Escribir("INVENTARIO");
            Escribir("═════════════════════════════");
            foreach (string item in juego.Inventario)
            {
                Escribir("• " + item);
            }
        }

        private void MostrarAyuda()
        {
            Escribir("");
            Escribir("═════════════════════════════");
            Escribir("COMANDOS");
            Escribir("═════════════════════════════");

            Escribir("Movimiento:");
            Escribir("• entrar");
            Escribir("• ir baño");
            Escribir("• ir cocina");
            Escribir("• ir patio");
            Escribir("• ir sotano");
            Escribir("• ir habitacion");
            Escribir("• ir pasillo");
            Escribir("• ir entrada");
            Escribir("• ir auto");

            Escribir("");

            Escribir("Interacción:");
            Escribir("• examinar");
            Escribir("• tomar llave");
            Escribir("• usar llave");
            Escribir("• tomar radio");
            Escribir("• usar radio");
            Escribir("• tomar combustible");
            Escribir("• usar combustible");

            Escribir("");

            Escribir("Información:");
            Escribir("• inventario");
            Escribir("• ayuda");

            Escribir("═════════════════════════════");
        }

        private void picEscena_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)

        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblpprompt_Click(object sender, EventArgs e)
        {

        }
    }
}