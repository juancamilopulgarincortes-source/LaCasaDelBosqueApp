using LaCasaDelBosqueMobile.Modelos;

namespace LaCasaDelBosqueMobile
{
    public partial class MainPage : ContentPage
    {
        private readonly Juego juego = new Juego();

        public MainPage()
        {
            InitializeComponent();

            MostrarEscena();
            AgregarHistoria("La lluvia golpea el parabrisas...");
            AgregarHistoria("Escribe 'entrar' para entrar en la casa o 'ayuda' para ver los comandos.");
        }

        private void OnEnviarClicked(object? sender, EventArgs e)
        {
            ProcesarComando();
        }

        private void OnComandoCompleted(object? sender, EventArgs e)
        {
            ProcesarComando();
        }

        private void ProcesarComando()
        {
            string comando = txtComando.Text?.Trim().ToLowerInvariant() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(comando))
                return;

            txtComando.Text = string.Empty;

            AgregarHistoria($"> {comando}");

            switch (comando)
            {
                // Movimiento
                case "entrar":
                    EjecutarMovimiento(juego.Entrar(), "Entras en la casa.", "No puedes entrar desde aquí.");
                    break;

                case "ir entrada":
                    EjecutarMovimiento(juego.IrEntrada(), "Regresas a la entrada.", "No puedes ir a la entrada desde aquí.");
                    break;

                case "ir pasillo":
                    EjecutarMovimiento(juego.IrPasillo(), "Regresas al pasillo.", "No puedes ir al pasillo desde aquí.");
                    break;

                case "ir cocina":
                    EjecutarMovimiento(juego.IrCocina(), "Entras en la cocina.", "No puedes ir a la cocina desde aquí.");
                    break;

                case "ir baño":
                case "ir bano":
                    EjecutarMovimiento(juego.IrBaño(), "Entras en el baño.", "No puedes ir al baño desde aquí.");
                    break;

                case "ir patio":
                    EjecutarMovimiento(juego.IrPatio(), "Sales al patio.", "No puedes ir al patio desde aquí.");
                    break;

                case "ir sotano":
                case "ir sótano":
                    EjecutarMovimiento(juego.IrSotano(), "Bajas al sótano.", "No puedes ir al sótano desde aquí.");
                    break;

                case "ir habitacion":
                case "ir habitación":
                    EjecutarMovimiento(juego.IrHabitacion(), "Entras en la habitación.", "No puedes entrar a la habitación. Tal vez la puerta esté cerrada.");
                    break;

                case "ir auto":
                    EjecutarMovimiento(juego.IrAuto(), "Te acercas al automóvil.", "No puedes ir al automóvil desde aquí.");
                    break;

                // Objetos
                case "tomar llave":
                    EjecutarAccion(
                        juego.TomarLlave(),
                        "Tomas la llave oxidada y la guardas en tu inventario.",
                        "No puedes tomar la llave aquí o ya la tienes.");
                    break;

                case "tomar radio":
                    EjecutarAccion(
                        juego.TomarRadio(),
                        "Tomas la radio y la guardas en tu inventario.",
                        "No puedes tomar la radio aquí o ya la tienes.");
                    break;

                case "tomar combustible":
                    EjecutarAccion(
                        juego.TomarCombustible(),
                        "Tomas el bidón de combustible.",
                        "No puedes tomar el combustible aquí o ya lo tienes.");
                    break;

                // Interacciones
                case "usar llave":
                    EjecutarAccion(
                        juego.UsarLlave(),
                        "Usas la llave. La puerta de la habitación se abre.",
                        "No puedes usar la llave aquí, no tienes la llave o la puerta ya está abierta.");
                    break;

                case "usar combustible":
                    EjecutarAccion(
                        juego.UsarCombustible(),
                        "Viertes el combustible en el automóvil. Ahora puedes intentar arrancarlo.",
                        "No puedes usar el combustible aquí o no lo tienes.");
                    break;

                case "usar radio":
                    if (juego.UsarRadio())
                    {
                        AgregarHistoria("Enciendes la radio. Solo se escucha estática entre algunos sonidos débiles.");
                    }
                    else
                    {
                        AgregarHistoria("No tienes una radio.");
                    }
                    break;

                case "arrancar":
                    ArrancarAuto();
                    break;

                // Información
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
                    AgregarHistoria("No entiendo ese comando. Escribe 'ayuda' para ver los comandos disponibles.");
                    break;
            }

            MostrarEscena();
            txtComando.Focus();
        }

        private void EjecutarMovimiento(bool sePuedeMover, string mensajeExito, string mensajeError)
        {
            if (sePuedeMover)
            {
                AgregarHistoria(mensajeExito);
            }
            else
            {
                AgregarHistoria(mensajeError);
            }
        }

        private void EjecutarAccion(bool sePuedeHacer, string mensajeExito, string mensajeError)
        {
            if (sePuedeHacer)
            {
                AgregarHistoria(mensajeExito);
            }
            else
            {
                AgregarHistoria(mensajeError);
            }
        }

        private void ArrancarAuto()
        {
            if (!juego.PuedeArrancar())
            {
                AgregarHistoria("El automóvil no puede arrancar. Necesitas combustible y debes estar junto al automóvil.");
                return;
            }

            AgregarHistoria("Giras la llave. El motor tose una vez... y finalmente arranca.");
            AgregarHistoria("¡Has conseguido escapar de la casa del bosque!");
            imgEscena.Source = "fin.png";
        }

        private void Examinar()
        {
            switch (juego.Ubicacion)
            {
                case "Entrada":
                    AgregarHistoria("La entrada está empapada por la lluvia. La puerta de la casa está frente a ti.");
                    break;

                case "Pasillo":
                    AgregarHistoria("El pasillo es oscuro. Hay varias puertas y el sonido de la lluvia llega desde el exterior.");
                    break;

                case "Cocina":
                    if (!juego.LlaveTomada)
                        AgregarHistoria("Sobre la mesa hay una vieja llave oxidada.");
                    else
                        AgregarHistoria("La mesa está vacía. Solo quedan marcas en el polvo donde estaba la llave.");
                    break;

                case "Baño":
                    if (!juego.RadioTomada)
                        AgregarHistoria("El baño está abandonado. Encuentras una vieja radio.");
                    else
                        AgregarHistoria("El baño está vacío. Ya no queda nada que puedas tomar.");
                    break;

                case "Patio":
                    AgregarHistoria("La lluvia ha convertido la tierra en barro. Entre la maleza descubres una vieja escotilla que parece conducir al sótano.");
                    break;

                case "Sotano":
                    if (!juego.CombustibleTomado)
                        AgregarHistoria("El sótano huele intensamente a gasolina. Junto a la pared hay un viejo bidón de combustible.");
                    else
                        AgregarHistoria("El sótano está vacío. Solo queda una marca húmeda donde estaba el bidón.");
                    break;

                case "Habitacion":
                    if (!juego.SombraVista)
                    {
                        juego.SombraVista = true;
                        AgregarHistoria("Una figura oscura aparece al fondo de la habitación... Cuando vuelves a mirar, ha desaparecido.");
                    }
                    else
                    {
                        AgregarHistoria("La habitación está vacía. La figura oscura ya no está.");
                    }
                    break;

                case "Auto":
                    if (!juego.AutoConCombustible)
                        AgregarHistoria("El automóvil está viejo y cubierto de gotas de lluvia. Parece necesitar combustible.");
                    else
                        AgregarHistoria("El automóvil tiene combustible. Quizá puedas arrancarlo.");
                    break;
            }
        }

        private void MostrarInventario()
        {
            if (juego.Inventario.Count == 0)
            {
                AgregarHistoria("Inventario: vacío.");
                return;
            }

            AgregarHistoria("Inventario:");

            foreach (string item in juego.Inventario)
            {
                AgregarHistoria($"• {item}");
            }
        }

        private void MostrarAyuda()
        {
            AgregarHistoria("Comandos disponibles:");
            AgregarHistoria("Movimiento: entrar, ir entrada, ir pasillo, ir cocina, ir baño, ir patio, ir sotano, ir habitacion, ir auto.");
            AgregarHistoria("Objetos: tomar llave, tomar radio, tomar combustible.");
            AgregarHistoria("Interacción: usar llave, usar radio, usar combustible, arrancar, examinar.");
            AgregarHistoria("Información: inventario, ayuda.");
        }

        private void MostrarEscena()
        {
            lblUbicacion.Text = $"📍 {juego.Ubicacion}";

            string imagen = juego.Ubicacion switch
            {
                "Entrada" => "entrada.png",
                "Pasillo" => "pasillo.png",
                "Cocina" => juego.LlaveTomada ? "cocinasinllave.png" : "cocina.png",
                "Baño" => juego.RadioTomada ? "banosinradio.png" : "bano.png",
                "Patio" => "patio.png",
                "Sotano" => juego.CombustibleTomado ? "sotano2.png" : "sotano1.png",
                "Habitacion" => juego.SombraVista ? "habitacionsinsombra.png" : "habitacion.png",
                "Auto" => "autolluvia.png",
                _ => "entrada.png"
            };

            if (juego.PuertaHabitacionAbierta && juego.Ubicacion == "Pasillo")
            {
                // Si luego quieres una imagen especial del pasillo con la puerta abierta,
                // puedes reemplazar esta línea por "puertaabierta.png".
                imagen = "pasillo.png";
            }

            imgEscena.Source = imagen;
        }

        private void AgregarHistoria(string texto)
        {
            if (string.IsNullOrWhiteSpace(lblHistoria.Text))
                lblHistoria.Text = texto;
            else
                lblHistoria.Text += Environment.NewLine + texto;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(50);
                await scrollHistoria.ScrollToAsync(0, double.MaxValue, true);
            });
        }
    }
}
