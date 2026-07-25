using System.Collections.Generic;

namespace LaCasaDelBosqueApp
{
    public class Juego
    {
        public string Ubicacion = "Entrada";

        public List<string> Inventario = new List<string>();

        public bool PuertaHabitacionAbierta = false;

        public bool RadioTomada = false;

        public bool LlaveTomada = false;

        public bool SombraVista = false;

        public bool CombustibleTomado = false;

        public bool AutoConCombustible = false;
    }
}
