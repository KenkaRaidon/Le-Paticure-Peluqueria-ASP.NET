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
    public class N_Usuario
    {
        readonly D_SQL_Datos sqlD = new D_SQL_Datos();

        public string InsertarUsuario(E_Usuario pUsuario)
        {
            pUsuario.Accion = "INSERTAR";
            string R = sqlD.IBM_Entidad<E_Usuario>("IBM_Usuarios", pUsuario);
            if (R.Contains("Exito"))
                return "Exito se ha introducido los datos correctamente";
            return "Error los datos no se han introducido";
        }
        public string BorrarUsuario(int pIdUsuario)
        {
            E_Usuario Usuario = new E_Usuario()
            {
                Accion = "BORRAR",
                IdUsuario = pIdUsuario
            };
            string R = sqlD.IBM_Entidad<E_Usuario>("IBM_Usuarios", Usuario);
            if (R.Contains("Exito"))
                return "Exito se han borrado los datos correctamente";
            return "Error los datos no se han borrado";
        }
        public string ModificarUsuario(E_Usuario pUsuario)
        {
            pUsuario.Accion = "MODIFICAR";
            string R = sqlD.IBM_Entidad<E_Usuario>("IBM_Usuarios", pUsuario);
            if (R.Contains("Exito"))
                return "Exito se han modificado los datos correctamente";
            return "Error los datos no se han modificado";
        }
        public DataTable DT_LstUsuarios() { return sqlD.DT_ListadoGeneral("Usuarios", "IdUsuario"); }
        public List<E_Usuario> LstUsuarios() { return DatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Usuario>(DT_LstUsuarios()); }
        public E_Usuario BuscarUsuario(int pIdUsuario)
        {
            return (from Usuario in LstUsuarios() where Usuario.IdUsuario == pIdUsuario select Usuario).SingleOrDefault();
        }
        public List<E_Usuario> LstBuscarUsuario(string pCriterioBusqueda)
        {
            return (from Usuarios in LstUsuarios()
                    where Usuarios.NombreUsuario.Contains(pCriterioBusqueda) ||
                    Usuarios.PasswordUsuario.Contains(pCriterioBusqueda) 
                    select Usuarios).ToList<E_Usuario>();
        }
        public E_Usuario Login(string pNickname, string pPassword)
        {
            return (from Usuario in LstUsuarios() where Usuario.NombreUsuario == pNickname && Usuario.PasswordUsuario == pPassword select Usuario).SingleOrDefault();
        }
    }
}
