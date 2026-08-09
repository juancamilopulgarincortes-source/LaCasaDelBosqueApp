using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LaCasaDelBosqueApp.Utilidades;

namespace LaCasaDelBosqueApp.Servicios
{
    public class GestorTemporizador
    {
        private readonly Timer timer;
        private List<PasoEvento> pasos = new List<PasoEvento>();
        private int pasoActual = 0;

        private readonly Action habilitarControles;

        public GestorTemporizador(Action habilitarControles)
        {
            this.habilitarControles = habilitarControles;

            timer = new Timer();
            timer.Tick += Timer_Tick;
        }

        public void Iniciar(List<PasoEvento> nuevosPasos)
        {
            if (nuevosPasos == null || nuevosPasos.Count == 0)
                return;

            pasos = nuevosPasos;
            pasoActual = 0;

            timer.Stop();
            timer.Interval = pasos[0].Espera;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pasoActual < pasos.Count)
            {
                pasos[pasoActual].Accion();

                pasoActual++;

                if (pasoActual < pasos.Count)
                {
                    timer.Interval = pasos[pasoActual].Espera;
                }
                else
                {
                    timer.Stop();
                    habilitarControles?.Invoke();
                }
            }
        }

        public void Detener()
        {
            timer.Stop();
        }
    }
}