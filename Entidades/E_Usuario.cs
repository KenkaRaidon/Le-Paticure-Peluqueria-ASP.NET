using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuario
    {
        #region Atributos
        private string _Accion;
        private int _IdUsuario;
        private string _NombreUsuario;
        private string _PasswordUsuario;
        private int _IdEmpleado;
        #endregion

        #region Constructores
        public E_Usuario(string accion, int idUsuario, string nombreUsuario, string passwordUsuario, int idEmpleado)
        {
            Accion = accion;
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            PasswordUsuario = passwordUsuario;
            IdEmpleado = idEmpleado;
        }
        public E_Usuario()
        {
            Accion = string.Empty;
            IdUsuario = 0;
            NombreUsuario = string.Empty;
            PasswordUsuario = string.Empty;
            IdEmpleado = 0;
        }
        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string PasswordUsuario { get => _PasswordUsuario; set => _PasswordUsuario = value; }
        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        #endregion
    }
}
