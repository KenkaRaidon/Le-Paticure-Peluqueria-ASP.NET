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
    public class N_Mascota
    {
        readonly D_SQL_Datos sqlD = new D_SQL_Datos();

        public string InsertarMascota(E_Mascota pMascota)
        {
            pMascota.Accion = "INSERTAR";
            string R = sqlD.IBM_Entidad<E_Mascota>("IBM_Mascotas", pMascota);
            if (R.Contains("Exito"))
                return "Exito se ha introducido los datos correctamente";
            return "Error los datos no se han introducido";
        }
        public string BorrarMascota(int pIdMascota)
        {
            E_Mascota Mascota = new E_Mascota()
            {
                Accion = "BORRAR",
                IdMascota = pIdMascota
            };
            string R = sqlD.IBM_Entidad<E_Mascota>("IBM_Mascotas", Mascota);
            if (R.Contains("Exito"))
                return "Exito se han borrado los datos correctamente";
            return "Error los datos no se han borrado";
        }
        public string ModificarMascota(E_Mascota pMascota)
        {
            pMascota.Accion = "MODIFICAR";
            string R = sqlD.IBM_Entidad<E_Mascota>("IBM_Mascotas", pMascota);
            if (R.Contains("Exito"))
                return "Exito se han modificado los datos correctamente";
            return "Error los datos no se han modificado";
        }
        public DataTable DT_LstMascotas() { return sqlD.DT_ListadoGeneral("Mascotas", "IdMascota"); }
        public List<E_Mascota> LstMascotas() { return DatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Mascota>(DT_LstMascotas()); }
        public E_Mascota BuscarMascota(int pIdMascota)
        {
            return (from Mascota in LstMascotas() where Mascota.IdMascota == pIdMascota select Mascota).SingleOrDefault();
        }
        public List<E_Mascota> LstBuscarMascota(string pCriterioBusqueda)
        {
            return (from Mascotas in LstMascotas()
                    where Mascotas.NombreMascota.Contains(pCriterioBusqueda) ||
                    Mascotas.ClaveMascota.Contains(pCriterioBusqueda)||
                    Mascotas.TelCelDueño.Contains(pCriterioBusqueda)||
                    Mascotas.EmailDueño.Contains(pCriterioBusqueda)
                    select Mascotas).ToList<E_Mascota>();
        }
        
    }
}
