using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Acceso_a_Datos;



namespace Negocio
{
    public class EspecialidadNegocio
    {

        public List<Especialidad> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<Especialidad> lista = new List<Especialidad>();
            try
            {
                datos.setearConsulta("select Nombre, Id from Especialidad");
                datos.ejecutarLectura();
                Especialidad aux = new Especialidad();
                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
            
        }
        public List<Especialidad> listarFiltrado(Especialidad especialidad)
        {

            AccesoDatos datos = new AccesoDatos();
            List<Especialidad> lista = new List<Especialidad>();
            try
            {
                datos.setearConsulta("select Nombre, Id from Especialidad where Id = @IdEspecialidad");
                datos.setearParametro("@IdEspecialidad", especialidad.Id);
                datos.ejecutarLectura();

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
