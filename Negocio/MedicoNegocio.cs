using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Acceso_a_Datos;

namespace Negocio
{
    public class MedicoNegocio
    {
        public List<Medico> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<Medico> lista = new List<Medico>();
            try
            {
                datos.setearConsulta("select Nombre, Apellido, Id from Medico");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    //Id, Nombre, Apellido, Turnos(lista), Especialidades(lista), TurnosTrabajo(Lista)
                    
                    Medico aux = new Medico();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
            //Turnos
                    //Turno: Id, Paciente(obj), Medico(obj), Especialidad(obj), FechaHora, Observaciones, Estado
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    turnoNegocio.listarFiltradoMedico(aux);
                    aux.Turnos = new List<Turno>();
                    aux.Turnos = turnoNegocio.listarFiltradoMedico(aux);
                    int cuentaturnos = aux.Turnos.Count;

            //Especialidades
                    EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                    aux.Especialidades = new List<Especialidad>();
                    aux.Especialidades = especialidadNegocio.listarFiltradoMedico(aux);
                    int cuentaEspecialidades = aux.Especialidades.Count;
            //Turnos de trabajo
                    // Id, hEntrada, hSalida, Nombre
                    TurnoTrabajoNegocio TTNegocio = new TurnoTrabajoNegocio();
                    aux.TurnosTrabajo = new List<TurnoTrabajo>();
                    aux.TurnosTrabajo = TTNegocio.listarFiltradoMedico(aux);
                    int cuentaTurnosTRabajo = aux.TurnosTrabajo.

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
        public List<Medico> listarFiltrado(Medico medico)
        {

            AccesoDatos datos = new AccesoDatos();
            List<Medico> lista = new List<Medico>();
            try
            {
                datos.setearConsulta("select Nombre, Apellido, Id from Medico where Id = @IdMedico");
                datos.setearParametro("@IdMedico", medico.Id);
                datos.ejecutarLectura();
                Medico aux = new Medico();
                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Apellido = (string)datos.Lector["Apellido"];
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
