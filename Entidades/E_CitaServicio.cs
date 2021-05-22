using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_CitaServicio
    {
        private string _Accion;
        private int _IdCitaServicio;
        private int _IdCita;
        private int _IdServicio;

        public E_CitaServicio()
        {
            _Accion = string.Empty;
            _IdCitaServicio = 0;
            _IdCita = 0;
            _IdServicio = 0;
        }

        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdCitaServicio { get => _IdCitaServicio; set => _IdCitaServicio = value; }
        public int IdCita { get => _IdCita; set => _IdCita = value; }
        public int IdServicio { get => _IdServicio; set => _IdServicio = value; }
    }
}
