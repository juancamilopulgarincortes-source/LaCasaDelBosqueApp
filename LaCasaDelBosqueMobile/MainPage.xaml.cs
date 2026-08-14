using LaCasaDelBosqueMobile.Modelos;

namespace LaCasaDelBosqueMobile
{
    public partial class MainPage : ContentPage
    {
        private readonly Juego juego = new Juego();

        public MainPage()
        {
            InitializeComponent();

            lblHistoria.Text = "La lluvia golpea el parabrisas...";
        }

        private void OnEnviarClicked(object? sender, EventArgs e)
        {
            string comando = txtComando.Text?.Trim().ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(comando))
                return;

            txtComando.Text = "";

            lblHistoria.Text += Environment.NewLine + "> " + comando;

            switch (comando)
            {
                case "entrar":

                    if (juego.Entrar())
                    {
                        lblUbicacion.Text = "📍 Pasillo";

                        lblHistoria.Text += Environment.NewLine;
                        lblHistoria.Text += "Entras en la casa.";
                    }
                    else
                    {
                        lblHistoria.Text += Environment.NewLine;
                        lblHistoria.Text += "No puedes entrar desde aquí.";
                    }

                    break;

                case "ir cocina":

                    if (juego.IrCocina())
                    {
                        lblUbicacion.Text = "📍 Cocina";

                        lblHistoria.Text += Environment.NewLine;
                        lblHistoria.Text += "Entras en la cocina.";
                    }
                    else
                    {
                        lblHistoria.Text += Environment.NewLine;
                        lblHistoria.Text += "No puedes ir a la cocina desde aquí.";
                    }

                    break;

                default:

                    lblHistoria.Text += Environment.NewLine;
                    lblHistoria.Text += "Comando no reconocido.";

                    break;
            }

            txtComando.Focus();
        }

        private void OnComandoCompleted(object? sender, EventArgs e)
        {
            OnEnviarClicked(sender, e);
        }
    }
}