using System;
using System.Windows.Forms;
using LaCasaDelBosqueApp.Modelos;

namespace LaCasaDelBosqueApp.Servicios
{
    internal class GestorMovimiento
    {
        private readonly Juego juego;
        private readonly GestorImagenes gestorImagenes;
        private readonly PictureBox picEscena;
        private readonly Label lblUbicacion;
        private readonly Action<string> escribir;

        public GestorMovimiento(
            Juego juego,
            GestorImagenes gestorImagenes,
            PictureBox picEscena,
            Label lblUbicacion,
            Action<string> escribir)
        {
            this.juego = juego;
            this.gestorImagenes = gestorImagenes;
            this.picEscena = picEscena;
            this.lblUbicacion = lblUbicacion;
            this.escribir = escribir;
        }
    }
}