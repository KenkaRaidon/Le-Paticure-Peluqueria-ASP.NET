using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Mascota
    {
        #region Atributos
        private string _Accion;
        private int _IdMascota;
        private string _ClaveMascota;
        private string _NombreMascota;
        private int _IdRaza;
        private string _TelCelDueño;
        private string _EmailDueño;
        #endregion

        #region Constructores
        public E_Mascota()
        {
            _Accion = string.Empty;
            _IdMascota = 0;
            _ClaveMascota = string.Empty;
            _NombreMascota = string.Empty;
            _IdRaza = 0;
            _TelCelDueño = string.Empty;
            _EmailDueño = string.Empty;
        }
        public E_Mascota(string accion, int idMascota, string claveMascota, string nombreMascota, int idRaza, string telCelDueño, string emailDueño)
        {
            _Accion = accion;
            _IdMascota = idMascota;
            _ClaveMascota = claveMascota;
            _NombreMascota = nombreMascota;
            _IdRaza = idRaza;
            _TelCelDueño = telCelDueño;
            _EmailDueño = emailDueño;
        }
        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdMascota { get => _IdMascota; set => _IdMascota = value; }
        public string ClaveMascota { get => _ClaveMascota; set => _ClaveMascota = value; }
        public string NombreMascota { get => _NombreMascota; set => _NombreMascota = value; }
        public int IdRaza { get => _IdRaza; set => _IdRaza = value; }
        public string TelCelDueño { get => _TelCelDueño; set => _TelCelDueño = value; }
        public string EmailDueño { get => _EmailDueño; set => _EmailDueño = value; }
        #endregion
    }
}
