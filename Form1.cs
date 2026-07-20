using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace LaCasaDelBosqueApp

{
    public partial class Form1 : Form
    {

        Juego juego = new Juego();
        private System.Windows.Forms.Timer timerIntro = new System.Windows.Forms.Timer();
        private int pasoIntro = 0;
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnEnviar;
            this.Shown += (s, e) =>
            {
                txtComando.Focus();
                this.ActiveControl = txtComando;
                Introduccion();
            };
        }
        private void CambiarImagen(string nombreImagen)
        {
            string ruta = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "imagenes",
            nombreImagen);
            //MessageBox.Show(File.Exists(ruta).ToString());
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
        private void Introduccion()
        {
            txtComando.Enabled = false;
            btnEnviar.Enabled = false;

            rtbHistoria.Clear();

            CambiarImagen("autolluvia.png");

            pasoIntro = 0;

            timerIntro.Interval = 2000; 
            timerIntro.Tick -= TimerIntro_Tick;
            timerIntro.Tick += TimerIntro_Tick;
            timerIntro.Start();
        }
        private void TimerIntro_Tick(object sender, EventArgs e)
        {
            switch (pasoIntro)
            {
                case 0:
                    Escribir("═════════════════════════");
                    Escribir(" LA CASA DEL BOSQUE");
                    Escribir("═════════════════════════");
                    break;

                case 1:
                    Escribir("");
                    Escribir("La lluvia golpea el parabrisas...");
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
                    CambiarImagen("entrada.png");
                    Escribir("");
                    Escribir("Escribe 'ayuda' para ver los comandos.");
                    juego.Ubicacion = "Entrada";
                    lblUbicacion.Text = "📍 Entrada";

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
            string comando = txtComando.Text.ToLower();

            txtComando.Clear();

            switch (comando)
            {
                case "entrar":
                    {
                        juego.Ubicacion = "Pasillo";

                        if (juego.PuertaHabitacionAbierta)
                            CambiarImagen("puertaabierta.png");
                        else
                            CambiarImagen("pasillo.png");

                        lblUbicacion.Text = "📍 Pasillo";
                        Escribir("");
                        Escribir("[ PASILLO ]");
                        Escribir("Entras a la casa.");
                    }

                    break;

                case "ir entrada":

                    if (juego.Ubicacion == "Pasillo")
                    {
                        juego.Ubicacion = "Entrada";
                        CambiarImagen("entrada.png");
                        lblUbicacion.Text = "📍 Entrada";
                        Escribir("");
                        Escribir("[ ENTRADA ]");
                        Escribir("Sales de la casa y vuelves a la entrada.");
                    }
                    else if (juego.Ubicacion == "Auto")
                    {
                        juego.Ubicacion = "Entrada";
                        CambiarImagen("entrada.png");
                        lblUbicacion.Text = "📍 Entrada";
                        Escribir("");
                        Escribir("[ ENTRADA ]");
                        Escribir("Te alejas del automóvil y vuelves frente a la casa.");
                    }

                    break;

                case "ir auto":

                    if (juego.Ubicacion == "Entrada")
                    {
                        juego.Ubicacion = "Auto";
                        CambiarImagen("autolluvia.png");
                        lblUbicacion.Text = "📍 Auto";
                        Escribir("");
                        Escribir("[ AUTO ]");
                        Escribir("Regresas al automóvil.");
                    }

                    break;

                case "ir baño":

                    if (juego.Ubicacion == "Pasillo")
                    {
                        juego.Ubicacion = "Baño";
                        if (juego.RadioTomada)
                            CambiarImagen("banosinradio.png");
                        else
                            CambiarImagen("bano.png");

                        lblUbicacion.Text = "📍 Baño";
                        Escribir("");
                        Escribir("[ BAÑO ]");
                        Escribir("Llegas al baño.");
                    }

                    break;

                case "ir cocina":

                    if (juego.Ubicacion == "Pasillo")
                    {
                        juego.Ubicacion = "Cocina";
                        if (juego.LlaveTomada)
                            CambiarImagen("cocinasinllave.png");
                        else
                            CambiarImagen("cocina.png");

                        lblUbicacion.Text = "📍 Cocina";
                        Escribir("");
                        Escribir("[ COCINA ]");
                        Escribir("Llegas a la cocina.");
                    }

                    break;

                case "ir pasillo":

                    if (juego.Ubicacion == "Cocina" ||
                        juego.Ubicacion == "Baño" ||
                        juego.Ubicacion == "Habitacion" ||
                        juego.Ubicacion == "Entrada")
                    {
                        juego.Ubicacion = "Pasillo";
                        if (juego.PuertaHabitacionAbierta)
                            CambiarImagen("puertaabierta.png");
                        else
                            CambiarImagen("pasillo.png");

                        lblUbicacion.Text = "📍 Pasillo";
                        Escribir("");
                        Escribir("[ PASILLO ]");
                        Escribir("Regresas al pasillo.");
                    }

                    break;

                case "ir habitacion":

                    if (juego.Ubicacion == "Pasillo")
                    {
                        if (juego.PuertaHabitacionAbierta)
                        {
                            juego.Ubicacion = "Habitacion";

                            if (juego.SombraVista)
                                CambiarImagen("habitacionsinsombra.png");
                            else
                                CambiarImagen("habitacion.png");
                            lblUbicacion.Text = "📍 Habitacion";
                            Escribir("");
                            Escribir("[ HABITACION ]");
                            Escribir("Entras a la habitación.");
                        }
                        else
                        {
                            Escribir("");
                            Escribir("[ HABITACION ]");
                            Escribir("La puerta está cerrada. Necesitas una llave.");
                        }
                    }

                    break;

                case "tomar radio":

                    if (juego.Ubicacion == "Baño" &&
                        !juego.Inventario.Contains("radio"))
                    {
                        juego.Inventario.Add("radio");
                        juego.RadioTomada = true;

                        CambiarImagen("banosinradio.png");

                        Escribir("");
                        Escribir("[ TOMAR RADIO ]");
                        Escribir("Has tomado la radio.");
                    }

                    break;

                case "usar radio":

                    if (juego.Inventario.Contains("radio"))
                    {
                        Escribir("");
                        Escribir("[ USAR RADIO ]");
                        Escribir("");
                        Escribir("*sssshhhhhhhhh*");
                        
                        Escribir("");
                        Escribir("*crrrrkkkk*");
                        
                        Escribir("");
                        Escribir("Entre la estática distingues una melodía lenta...");
                        
                        Escribir("");
                        Escribir("\"There was something I forgot to say\"");
                        
                        Escribir("");
                        Escribir("\"I was crying on Saturday night\"");
                        
                        Escribir("");
                        Escribir("*ssssshhhhhh*");
                        
                        Escribir("");
                        Escribir("La melodía se detiene de golpe.");
                    }
                    else
                    {
                        Escribir("");
                        Escribir("[ USAR RADIO ]");
                        Escribir("No tienes ninguna radio.");
                    }

                    break;

                case "examinar":
                    Examinar();
                    break;

                case "tomar llave":

                    if (juego.Ubicacion == "Cocina" &&
                        !juego.Inventario.Contains("llave"))
                    {
                        juego.Inventario.Add("llave");
                        juego.LlaveTomada = true;
                        CambiarImagen("cocinasinllave.png");
                        Escribir("");
                        Escribir("[ TOMAR LLAVE ]");
                        Escribir("Has tomado la llave.");
                    }

                    break;

                case "inventario":
                    MostrarInventario();
                    break;

                case "usar llave":

                    if (juego.Ubicacion == "Pasillo" &&
                        juego.Inventario.Contains("llave") &&
                        !juego.PuertaHabitacionAbierta)
                    {
                        juego.Inventario.Remove("llave");

                        juego.PuertaHabitacionAbierta = true;
                        CambiarImagen("puertaabierta.png");

                        Escribir("");
                        Escribir("[ USAR LLAVE ]");
                        Escribir("Usas la llave.");
                        Escribir("La puerta de la habitación se abre.");
                    }

                    break;

                case "ayuda":
                    Escribir("");
                    Escribir("═════════════════════════");
                    Escribir("       COMANDOS");
                    Escribir("═════════════════════════");

                    Escribir("Movimiento:");
                    Escribir("• entrar");
                    Escribir("• ir baño");
                    Escribir("• ir cocina");
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

                    Escribir("");

                    Escribir("Información:");
                    Escribir("• inventario");
                    Escribir("• ayuda");

                    Escribir("═════════════════════════");

                    break;

                default:
                    Escribir("");
                    Escribir("[ ERROR ]");
                    Escribir("No entiendo ese comando.");
                    break;
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

                case "Habitacion":
                    Escribir("");
                    Escribir("[ EXAMINAR ]");

                    if (!juego.SombraVista)
                    {
                        Escribir("Hay un dibujo infantil pegado a la pared.");
                        

                        Escribir("");
                        Escribir("Una figura oscura se asoma por la ventana.");
                        

                        Escribir("");
                        Escribir("La cortina se cierra de golpe.");
                        

                        juego.SombraVista = true;
                        CambiarImagen("habitacionsinsombra.png");
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
            Escribir("═════════════════════════");
            Escribir("       INVENTARIO");
            Escribir("═════════════════════════");
            Escribir("Inventario vacío.");
                return;
            }

            Escribir("");
            Escribir("═════════════════════════");
            Escribir("       INVENTARIO");
            Escribir("═════════════════════════");
            foreach (string item in juego.Inventario)
            {
                Escribir("• " + item);
            }
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
    }
}