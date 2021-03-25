using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Entidades;
using DatosSQL;

namespace Negocios
{
    public class N_Empleado
    {
        readonly D_SQL_Datos sqlD = new D_SQL_Datos();

        public string InsertarEmpleado(E_Empleado pEmpleado)
        {
            pEmpleado.Accion = "INSERTAR";
            string R = sqlD.IBM_Entidad<E_Empleado>("IBM_Empleado", pEmpleado);
            if (R.Contains("Exito"))
                return "Exito se ha introducido los datos correctamente";
            return "Error los datos no se han introducido";
        }
        public string BorrarEmpleado(int pIdEmpleado)
        {
            E_Empleado Empleado = new E_Empleado()
            {
                Accion = "BORRAR",
                IdEmpleado = pIdEmpleado
            };
            string R = sqlD.IBM_Entidad<E_Empleado>("IBM_Empleado", Empleado);
            if (R.Contains("Exito"))
                return "Exito se han borrado los datos correctamente";
            return "Error los datos no se han borrado";
        }
        public string ModificarEmpleado(E_Empleado pEmpleado)
        {
            pEmpleado.Accion = "MODIFICAR";
            string R = sqlD.IBM_Entidad<E_Empleado>("IBM_Empleado", pEmpleado);
            if (R.Contains("Exito"))
                return "Exito se han modificado los datos correctamente";
            return "Error los datos no se han modificado";
        }
        public DataTable DT_LstEmpleados() { return sqlD.DT_ListadoGeneral("Empleados", "IdEmpleado"); }
        public List<E_Empleado> LstEmpleados() { return DatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Empleado>(DT_LstEmpleados()); }
        public E_Empleado BuscarEmpleado(int pIdEmpleado)
        {
            return (from Empleado in LstEmpleados() where Empleado.IdEmpleado==pIdEmpleado select Empleado).SingleOrDefault();
        }
        public List<E_Empleado> LstBuscarEmpleado(string pCriterioBusqueda) {
            return (from Empleados in LstEmpleados()
                    where Empleados.ClaveEmpleado.Contains(pCriterioBusqueda) ||
                    Empleados.NombreEmpleado.Contains(pCriterioBusqueda) ||
                    Empleados.ApellidoEmpleado.Contains(pCriterioBusqueda) ||
                    Empleados.DireccionEmpleado.Contains(pCriterioBusqueda) ||
                    Empleados.TelCelEmpleado.Contains(pCriterioBusqueda) ||
                    Empleados.EmailEmpleado.Contains(pCriterioBusqueda)
                    select Empleados).ToList<E_Empleado>();
        }
    }
}
