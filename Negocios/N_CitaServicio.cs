using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Entidades;
using DatosSQL;
using System.Data.SqlClient;

namespace Negocios
{
    public class N_CitaServicio
    {
        readonly D_SQL_Datos sqlD = new D_SQL_Datos();
        public string InsertaCitaServicio(E_CitaServicio pCitaServicio)
        {
            pCitaServicio.Accion = "INSERTAR";
            string R = sqlD.IBM_Entidad<E_CitaServicio>("IBM_CitaServicio", pCitaServicio);
            if (R.Contains("Exito"))
                return "Exito se ha introducido los datos correctamente";
            return "Error los datos no se han introducido";
        }
        public string BorrarCitaServicio(int pIdCitaServicio)
        {
            E_CitaServicio CitaServicio = new E_CitaServicio()
            {
                Accion = "BORRAR",
                IdCitaServicio = pIdCitaServicio
            };
            string R = sqlD.IBM_Entidad<E_CitaServicio>("IBM_CitaServicio", CitaServicio);
            if (R.Contains("Exito"))
                return "Exito se han borrado los datos correctamente";
            return "Error los datos no se han borrado";
        }
        public string ModificarCitaServicio(E_CitaServicio pCitaServicio)
        {
            pCitaServicio.Accion = "MODIFICAR";
            string R = sqlD.IBM_Entidad<E_CitaServicio>("IBM_CitaServicio", pCitaServicio);
            if (R.Contains("Exito"))
                return "Exito se han modificado los datos correctamente";
            return "Error los datos no se han modificado";
        }
        public DataTable DT_LstCitaServicio() { return sqlD.DT_ListadoGeneral("Cita_Servicio", "IdCitaServicio"); }
        public List<E_CitaServicio> LstCitaServicio() { return DatosSQL.D_ConvierteDatos.ConvertirDTALista<E_CitaServicio>(DT_LstCitaServicio()); }
        public List<E_CitaServicio> BuscarCitaServicio(int pIdCita)
        {
            return (from CitaServicio in LstCitaServicio() where CitaServicio.IdCita == pIdCita select CitaServicio).ToList();
        }
        /*public List<E_Cita> LstBuscarCita(string pCriterioBusqueda)
        {
            return (from Citas in LstCitas()
                    where Citas.ClaveCita.Contains(pCriterioBusqueda)
                    select Citas).ToList<E_Cita>();
        }*/
    }
}
