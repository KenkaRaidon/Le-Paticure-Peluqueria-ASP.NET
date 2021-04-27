using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Cita
    {
        #region Atributos
        private string _Accion;
        private int _IdCita;
        private string _ClaveCita;
        private int _IdServicio;
        private int _IdMascota;
        private DateTime _FechaCita;
        #endregion

        #region Constructores
        public E_Cita()
        {
            _Accion = string.Empty;
            _IdCita = 0;
            _ClaveCita = string.Empty;
            _IdServicio = 0;
            _IdMascota = 0;
            _FechaCita = DateTime.Now;
        }

        public E_Cita(string accion, int idCita, string claveCita, int idServicio, int idMascota, DateTime fechaCita)
        {
            _Accion = accion;
            _IdCita = idCita;
            _ClaveCita = claveCita;
            _IdServicio = idServicio;
            _IdMascota = idMascota;
            _FechaCita = fechaCita;
        }

        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdCita { get => _IdCita; set => _IdCita = value; }
        public string ClaveCita { get => _ClaveCita; set => _ClaveCita = value; }
        public int IdServicio { get => _IdServicio; set => _IdServicio = value; }
        public int IdMascota { get => _IdMascota; set => _IdMascota = value; }
        public DateTime FechaCita { get => _FechaCita; set => _FechaCita = value; }
        #endregion
    }
}
