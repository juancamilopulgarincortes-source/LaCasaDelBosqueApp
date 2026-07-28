using System;

namespace LaCasaDelBosqueApp.Utilidades
{
    public class PasoEvento
    {
        public Action Accion { get; set; }
        public int Espera { get; set; }

        public PasoEvento(Action accion, int espera)
        {
            Accion = accion;
            Espera = espera;
        }
    }
}
