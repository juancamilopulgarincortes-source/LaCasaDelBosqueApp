using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LaCasaDelBosqueApp.Modelos;
using LaCasaDelBosqueApp.Servicios;
using LaCasaDelBosqueApp.Utilidades;

namespace LaCasaDelBosqueApp

{
    public partial class Form1 : Form
    {
        Juego juego = new Juego();
        GestorImagenes gestorImagenes;
        private ControladorComandos controlador;
        private System.Windows.Forms.Timer timerIntro = new System.Windows.Forms.Timer();
        private int pasoIntro = 0;
        private System.Windows.Forms.Timer timerEvento = new System.Windows.Forms.Timer();
        private List<PasoEvento> pasosEvento = new List<PasoEvento>();
        private int pasoEvento = 0;

        public Form1()
        {
            InitializeComponent();

            gestorImagenes = new GestorImagenes();

            controlador = new ControladorComandos(
                this,
                juego,
                gestorImagenes);

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
        private void MostrarTitulo(string titulo)
        {
            Escribir("");
            Escribir($"[ {titulo.ToUpper()} ]");
        }
        private void MostrarCabecera(string titulo)
        {
            Escribir("");
            Escribir("═════════════════════════════");
            Escribir(titulo.ToUpper());
            Escribir("═════════════════════════════");
        }
        private void EjecutarComando(string comando)
        {
            switch (comando)
            {
                case "arrancar":
                    Arrancar();
                    break;

                default:
                    controlador.Ejecutar(comando);
                    break;
            }
        }
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            string comando = txtComando.Text.Trim().ToLower();
            txtComando.Clear();

            EjecutarComando(comando);
        }
        private void Arrancar()
        {
            if (juego.Ubicacion != "Auto")
            {
                MostrarTitulo("Auto");
                Escribir("No estás dentro del automóvil.");
                return;
            }

            if (!juego.PuedeArrancar())
            {
                MostrarTitulo("Auto");
                Escribir("El automóvil no tiene combustible.");
                Escribir("Necesitas llenar el tanque antes de arrancarlo.");
                return;
            }
            
                IniciarEvento(new List<PasoEvento>
        {
            new PasoEvento(() =>
            {
                MostrarTitulo("Auto");
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
       
        public PictureBox Escena => picEscena;

        public Label UbicacionLabel => lblUbicacion;

        public void EscribirPublico(string texto)
        {
            Escribir(texto);
        }

        public void MostrarTituloPublico(string titulo)
        {
            MostrarTitulo(titulo);
        }
        public void MostrarCabeceraPublica(string titulo)
        {
            MostrarCabecera(titulo);
        }
        public void IniciarEventoPublico(List<PasoEvento> pasos)
        {
            IniciarEvento(pasos);
        }
        public void LimpiarHistoria()
        {
            rtbHistoria.Clear();
        }
    }
}