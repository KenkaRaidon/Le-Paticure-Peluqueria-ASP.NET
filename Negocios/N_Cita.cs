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
    public class N_Cita
    {
        readonly D_SQL_Datos sqlD = new D_SQL_Datos();

        /*public string InsertarCita(E_Cita pCita)
        {
            pCita.Accion = "INSERTAR";
            string R = sqlD.IBM_Entidad<E_Cita>("IBM_Citas", pCita);
            int id=pCita.IdCita;
            if (R.Contains("Exito"))
                return "Exito se ha introducido los datos correctamente";
            return "Error los datos no se han introducido";
        }*/
        public int InsertarCita(E_Cita pCita)
        {
            pCita.Accion = "INSERTAR";
            string con = "Data Source=DESKTOP-OTHRDKV\\SQLEXPRESS;Initial Catalog=PeluqueriaPeticure;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("IBM_Citas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCita", SqlDbType.Int).Value = pCita.IdCita;
            cmd.Parameters.Add("@Accion", SqlDbType.NVarChar, 25).Value = pCita.Accion;
            cmd.Parameters.Add("@ClaveCita", SqlDbType.NChar, 5).Value = pCita.ClaveCita;
            cmd.Parameters.Add("@IdMascota", SqlDbType.Int).Value = pCita.IdMascota;
            cmd.Parameters.Add("@FechaCita", SqlDbType.DateTime).Value = pCita.FechaCita;
            cmd.Parameters.Add("@Temp", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int IdCita = int.Parse(cmd.Parameters["@Temp"].Value.ToString());
            conn.Close();
            return IdCita;

        }
        public string BorrarCita(int pIdCita)
        {
            E_Cita Cita = new E_Cita()
            {
                Accion = "BORRAR",
                IdCita = pIdCita
            };
            string R = sqlD.IBM_Entidad<E_Cita>("IBM_Citas", Cita);
            if (R.Contains("Exito"))
                return "Exito se han borrado los datos correctamente";
            return "Error los datos no se han borrado";
        }
        public string ModificarCita(E_Cita pCita)
        {
            pCita.Accion = "MODIFICAR";
            string R = sqlD.IBM_Entidad<E_Cita>("IBM_Citas", pCita);
            if (R.Contains("Exito"))
                return "Exito se han modificado los datos correctamente";
            return "Error los datos no se han modificado";
        }
        public DataTable DT_LstCitas() { return sqlD.DT_ListadoGeneral("Cita", "IdCita"); }
        public List<E_Cita> LstCitas() { return DatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Cita>(DT_LstCitas()); }
        public E_Cita BuscarCita(int pIdCita)
        {
            return (from Cita in LstCitas() where Cita.IdCita == pIdCita select Cita).SingleOrDefault();
        }
        public List<E_Cita> LstBuscarCita(string pCriterioBusqueda)
        {
            return (from Citas in LstCitas()
                    where Citas.ClaveCita.Contains(pCriterioBusqueda)
                    select Citas).ToList<E_Cita>();
        }
    }
}
