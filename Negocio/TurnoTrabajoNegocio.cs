using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Acceso_a_Datos;
using System.Runtime.Remoting.Messaging;

namespace Negocio
{
    public class TurnoTrabajoNegocio
    {
        public List<TurnoTrabajo> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<TurnoTrabajo> lista = new List<TurnoTrabajo>();
            try
            {
                datos.setearConsulta("select HoraEntrada, HoraSalida, Nombre, Id from TurnoTrabajo");
                datos.ejecutarLectura();
                TurnoTrabajo aux = new TurnoTrabajo();
                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["HoraEntrada"] is DBNull))
                        aux.HoraEntrada = datos.Lector.GetTimeSpan(datos.Lector.GetOrdinal("HoraEntrada"));
                    if (!(datos.Lector["HoraSalida"] is DBNull))
                        aux.HoraSalida = datos.Lector.GetTimeSpan(datos.Lector.GetOrdinal("HoraSalida"));
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
        public List<TurnoTrabajo> listarFiltradoMedico(Medico medico)
        {

            AccesoDatos datos = new AccesoDatos();
            List<TurnoTrabajo> lista = new List<TurnoTrabajo>();
            try
            {
                datos.setearConsulta("select TT.HoraEntrada, TT.HoraSalida, TT.Nombre, TT.Id from TurnoTrabajo TT, [TurnoTrabajo.Medico] TTM where TTM.IdMedico = @IdMedico and TTM.IdTurnoTrabajo = TT.Id");
                datos.ejecutarLectura();
                datos.setearParametro("@IdMedico", medico.Id);
                TurnoTrabajo aux = new TurnoTrabajo();
                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["TT.Id"] is DBNull))
                        aux.Id = (int)datos.Lector["TT.Id"];
                    if (!(datos.Lector["TT.HoraEntrada"] is DBNull))
                        aux.HoraEntrada = datos.Lector.GetTimeSpan(datos.Lector.GetOrdinal("TT.HoraEntrada"));
                    if (!(datos.Lector["TT.HoraSalida"] is DBNull))
                        aux.HoraSalida = datos.Lector.GetTimeSpan(datos.Lector.GetOrdinal("TT.HoraSalida"));
                    if (!(datos.Lector["TT.Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["TT.Nombre"];

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

    }
}
