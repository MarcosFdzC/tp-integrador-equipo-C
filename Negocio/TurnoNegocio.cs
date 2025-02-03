using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Acceso_a_Datos;

namespace Negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar()
        {
			AccesoDatos datos = new AccesoDatos();
			List<Turno> lista = new List<Turno>();
			try
			{
				datos.setearConsulta("Select T.IdPaciente, T.IdMedico, T.IdEspecialidad, E.Nombre Especialidad, T.FechaHora, T.Observaciones, T.EstadoTurno, T.Id From Turno T, Especialidad E where T.IdEspecialidad = E.Id");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
                    Turno aux = new Turno();
			//Cargamos los datos del Paciente
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)datos.Lector["T.IdPaciente"];
                    PacienteNegocio PacienteNegocio = new PacienteNegocio();
                    List<Paciente> PacienteFiltrado = PacienteNegocio.listarFiltrado(aux.Paciente);
                    //Id, Nom,Apell, Dni, FechaNacimiento, Telefono, Email, Turnos
                    aux.Paciente.Nombre = PacienteFiltrado[0].Nombre;
                    aux.Paciente.Apellido = PacienteFiltrado[0].Apellido;
                    aux.Paciente.Dni = PacienteFiltrado[0].Dni;
                    aux.Paciente.FechaNacimiento = PacienteFiltrado[0].FechaNacimiento;
                    aux.Paciente.Telefono = PacienteFiltrado[0].Telefono;
                    aux.Paciente.Email = PacienteFiltrado[0].Email;
            //Cargamos los datos del medico(filtrado) sin las Listas de turno, especialidades y Turnos de Trabajo
                    //Id, Nombre, Apellido
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)datos.Lector["T.IdMedico"];
                    MedicoNegocio MedicoNegocio = new MedicoNegocio();
                    List<Medico> MedicoFiltrado = MedicoNegocio.listarFiltrado(aux.Medico);
                    aux.Medico.Nombre = MedicoFiltrado[0].Nombre;
                    aux.Medico.Apellido = MedicoFiltrado[0].Apellido;
            //Cargamos los datos de la especialidad(filtrado)
                    aux.Especialidad = new Especialidad();
					aux.Especialidad.Id = (int)datos.Lector["T.IdEspecialidad"];
					aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
            //Cargamos el resto de los datos del turno
					aux.FechaHora = (DateTime)datos.Lector["T.FechaHora"];
					if (!(datos.Lector["T.Observaciones"] is DBNull))
						aux.Observaciones = (string)datos.Lector["T.Observaciones"];
					int EstadoTurnoDB = 0;
					if ( !(datos.Lector["T.EstadoTurno"] is DBNull) )
						EstadoTurnoDB = (int)datos.Lector["T.EstadoTurno"];
						aux.Estado = (EstadoTurno)EstadoTurnoDB;
					aux.Id = (int)datos.Lector["T.Id"];
                    



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
        public List<Turno> listarFiltradoMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();
            try
            {
                datos.setearConsulta("Select T.IdPaciente, T.IdMedico, T.IdEspecialidad, E.Nombre Especialidad, T.FechaHora, T.Observaciones, T.EstadoTurno, T.Id From Turno T, Especialidad E where T.IdEspecialidad = E.Id and T.IdMedico = @IdMedico");
                datos.setearParametro("@IdMedico", medico.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    //Cargamos los datos del Paciente
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)datos.Lector["T.IdPaciente"];
                    PacienteNegocio PacienteNegocio = new PacienteNegocio();
                    List<Paciente> PacienteFiltrado = PacienteNegocio.listarFiltrado(aux.Paciente);
                    //Id, Nom,Apell, Dni, FechaNacimiento, Telefono, Email, Turnos
                    aux.Paciente.Nombre = PacienteFiltrado[0].Nombre;
                    aux.Paciente.Apellido = PacienteFiltrado[0].Apellido;
                    aux.Paciente.Dni = PacienteFiltrado[0].Dni;
                    aux.Paciente.FechaNacimiento = PacienteFiltrado[0].FechaNacimiento;
                    aux.Paciente.Telefono = PacienteFiltrado[0].Telefono;
                    aux.Paciente.Email = PacienteFiltrado[0].Email;
                    //Cargamos los datos del medico(filtrado) sin las Listas de turno, especialidades y Turnos de Trabajo
                    //Id, Nombre, Apellido
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)datos.Lector["T.IdMedico"];
                    MedicoNegocio MedicoNegocio = new MedicoNegocio();
                    List<Medico> MedicoFiltrado = MedicoNegocio.listarFiltrado(aux.Medico);
                    aux.Medico.Nombre = MedicoFiltrado[0].Nombre;
                    aux.Medico.Apellido = MedicoFiltrado[0].Apellido;
                    //Cargamos los datos de la especialidad(filtrado)
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["T.IdEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    //Cargamos el resto de los datos del turno
                    aux.FechaHora = (DateTime)datos.Lector["T.FechaHora"];
                    if (!(datos.Lector["T.Observaciones"] is DBNull))
                        aux.Observaciones = (string)datos.Lector["T.Observaciones"];
                    int EstadoTurnoDB = 0;
                    if (!(datos.Lector["T.EstadoTurno"] is DBNull))
                        EstadoTurnoDB = (int)datos.Lector["T.EstadoTurno"];
                    aux.Estado = (EstadoTurno)EstadoTurnoDB;
                    aux.Id = (int)datos.Lector["T.Id"];




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
        public List<Turno> listarFiltradoPaciente(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();
            try
            {
                datos.setearConsulta("Select T.IdPaciente, T.IdMedico, T.IdEspecialidad, E.Nombre Especialidad, T.FechaHora, T.Observaciones, T.EstadoTurno, T.Id From Turno T, Especialidad E where T.IdEspecialidad = E.Id and T.IdPaciente = @IdPaciente");
                datos.setearParametro("@IdPaciente", paciente.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    //Cargamos los datos del Paciente
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)datos.Lector["T.IdPaciente"];
                    PacienteNegocio PacienteNegocio = new PacienteNegocio();
                    List<Paciente> PacienteFiltrado = PacienteNegocio.listarFiltrado(aux.Paciente);
                    //Id, Nom,Apell, Dni, FechaNacimiento, Telefono, Email, Turnos
                    aux.Paciente.Nombre = PacienteFiltrado[0].Nombre;
                    aux.Paciente.Apellido = PacienteFiltrado[0].Apellido;
                    aux.Paciente.Dni = PacienteFiltrado[0].Dni;
                    aux.Paciente.FechaNacimiento = PacienteFiltrado[0].FechaNacimiento;
                    aux.Paciente.Telefono = PacienteFiltrado[0].Telefono;
                    aux.Paciente.Email = PacienteFiltrado[0].Email;
                    //Cargamos los datos del medico(filtrado) sin las Listas de turno, especialidades y Turnos de Trabajo
                    //Id, Nombre, Apellido
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)datos.Lector["T.IdMedico"];
                    MedicoNegocio MedicoNegocio = new MedicoNegocio();
                    List<Medico> MedicoFiltrado = MedicoNegocio.listarFiltrado(aux.Medico);
                    aux.Medico.Nombre = MedicoFiltrado[0].Nombre;
                    aux.Medico.Apellido = MedicoFiltrado[0].Apellido;
                    //Cargamos los datos de la especialidad(filtrado)
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["T.IdEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    //Cargamos el resto de los datos del turno
                    aux.FechaHora = (DateTime)datos.Lector["T.FechaHora"];
                    if (!(datos.Lector["T.Observaciones"] is DBNull))
                        aux.Observaciones = (string)datos.Lector["T.Observaciones"];
                    int EstadoTurnoDB = 0;
                    if (!(datos.Lector["T.EstadoTurno"] is DBNull))
                        EstadoTurnoDB = (int)datos.Lector["T.EstadoTurno"];
                    aux.Estado = (EstadoTurno)EstadoTurnoDB;
                    aux.Id = (int)datos.Lector["T.Id"];




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
        public List<Turno> listarFiltradoEspc(Especialidad especialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();
            try
            {
                datos.setearConsulta("Select T.IdPaciente, T.IdMedico, T.IdEspecialidad, E.Nombre Especialidad, T.FechaHora, T.Observaciones, T.EstadoTurno, T.Id From Turno T, Especialidad E where T.IdEspecialidad = E.Id and T.IdEspecialidad = @IdEspecialidad");
                datos.setearParametro("@IdEspecialidad", especialidad.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    //Cargamos los datos del Paciente
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)datos.Lector["T.IdPaciente"];
                    PacienteNegocio PacienteNegocio = new PacienteNegocio();
                    List<Paciente> PacienteFiltrado = PacienteNegocio.listarFiltrado(aux.Paciente);
                    //Id, Nom,Apell, Dni, FechaNacimiento, Telefono, Email, Turnos
                    aux.Paciente.Nombre = PacienteFiltrado[0].Nombre;
                    aux.Paciente.Apellido = PacienteFiltrado[0].Apellido;
                    aux.Paciente.Dni = PacienteFiltrado[0].Dni;
                    aux.Paciente.FechaNacimiento = PacienteFiltrado[0].FechaNacimiento;
                    aux.Paciente.Telefono = PacienteFiltrado[0].Telefono;
                    aux.Paciente.Email = PacienteFiltrado[0].Email;
                    //Cargamos los datos del medico(filtrado) sin las Listas de turno, especialidades y Turnos de Trabajo
                    //Id, Nombre, Apellido
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)datos.Lector["T.IdMedico"];
                    MedicoNegocio MedicoNegocio = new MedicoNegocio();
                    List<Medico> MedicoFiltrado = MedicoNegocio.listarFiltrado(aux.Medico);
                    aux.Medico.Nombre = MedicoFiltrado[0].Nombre;
                    aux.Medico.Apellido = MedicoFiltrado[0].Apellido;
                    //Cargamos los datos de la especialidad(filtrado)
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["T.IdEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    //Cargamos el resto de los datos del turno
                    aux.FechaHora = (DateTime)datos.Lector["T.FechaHora"];
                    if (!(datos.Lector["T.Observaciones"] is DBNull))
                        aux.Observaciones = (string)datos.Lector["T.Observaciones"];
                    int EstadoTurnoDB = 0;
                    if (!(datos.Lector["T.EstadoTurno"] is DBNull))
                        EstadoTurnoDB = (int)datos.Lector["T.EstadoTurno"];
                    aux.Estado = (EstadoTurno)EstadoTurnoDB;
                    aux.Id = (int)datos.Lector["T.Id"];


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
