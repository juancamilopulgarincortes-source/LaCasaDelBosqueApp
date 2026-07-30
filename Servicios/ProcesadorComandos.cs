using System;

namespace LaCasaDelBosqueApp.Servicios
{
    public class ProcesadorComandos
    {
        private Action<string> escribir;

        public ProcesadorComandos(Action<string> escribir)
        {
            this.escribir = escribir;
        }

        public void Procesar(string comando)
        {
            escribir("Procesando comando: " + comando);
        }
    }
}
