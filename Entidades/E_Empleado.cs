using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Empleado
    {
        #region Atributos
        private string _Accion;
        private int _IdEmpleado;
        private string _ClaveEmpleado;
        private string _NombreEmpleado;
        private string _ApellidoEmpleado;
        private string _DireccionEmpleado;
        private string _TelCelEmpleado;
        private string _EmailEmpleado;
        private bool _EstadoEmpleado;
        #endregion

        #region Constructores
        public E_Empleado()
        {
            _Accion = string.Empty;
            _IdEmpleado = 0;
            _ClaveEmpleado = string.Empty;
            _ClaveEmpleado = string.Empty;
            _NombreEmpleado = string.Empty;
            _ApellidoEmpleado = string.Empty;
            _DireccionEmpleado = string.Empty;
            _TelCelEmpleado = string.Empty;
            _EmailEmpleado = string.Empty;
            _EstadoEmpleado = true;
        }
        public E_Empleado(string accion, int idEmpleado, string claveEmpleado, string nombreEmpleado, string apellidoEmpleado, string direccionEmpleado, string telCelEmpleado, string emailEmpleado, bool estadoEmpleado)
        {
            _Accion = accion;
            _IdEmpleado = idEmpleado;
            _ClaveEmpleado = claveEmpleado;
            _NombreEmpleado = nombreEmpleado;
            _ApellidoEmpleado = apellidoEmpleado;
            _DireccionEmpleado = direccionEmpleado;
            _TelCelEmpleado = telCelEmpleado;
            _EmailEmpleado = emailEmpleado;
            _EstadoEmpleado = estadoEmpleado;
        }
        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public string ClaveEmpleado { get => _ClaveEmpleado; set => _ClaveEmpleado = value; }
        public string NombreEmpleado { get => _NombreEmpleado; set => _NombreEmpleado = value; }
        public string ApellidoEmpleado { get => _ApellidoEmpleado; set => _ApellidoEmpleado = value; }
        public string DireccionEmpleado { get => _DireccionEmpleado; set => _DireccionEmpleado = value; }
        public string TelCelEmpleado { get => _TelCelEmpleado; set => _TelCelEmpleado = value; }
        public string EmailEmpleado { get => _EmailEmpleado; set => _EmailEmpleado = value; }
        public bool EstadoEmpleado { get => _EstadoEmpleado; set => _EstadoEmpleado = value; }
        #endregion
    }
}
