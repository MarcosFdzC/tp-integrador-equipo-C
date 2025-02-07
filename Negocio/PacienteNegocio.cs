using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Acceso_a_Datos;

namespace Negocio
{
    public class PacienteNegocio
    {
		public List<Paciente> listar()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Paciente> lista = new List<Paciente>();
			try
			{
				datos.setearConsulta("select Nombre, Apellido, Dni, FechaNacimiento, Telefono, Email, Id from Paciente");
				datos.ejecutarLectura();
				Paciente aux = new Paciente();
				while (datos.Lector.Read())
				{
                    //Id, Nom,Apell, Dni, FechaNacimiento, Telefono, Email, Turnos
                    if (!(datos.Lector["Nombre"] is DBNull))
						aux.Nombre = (string)datos.Lector["Nombre"];
					if (!(datos.Lector["Apellido"] is DBNull))
						aux.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["Dni"] is DBNull))
                        aux.Dni = (int)datos.Lector["Dni"];
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    if (!(datos.Lector["Telefono"] is DBNull))
                        aux.Telefono = (int)datos.Lector["Telefono"];
                    if (!(datos.Lector["Email"] is DBNull))
                        aux.Email = (string)datos.Lector["Email"];
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
					//Ahora cargamos la lista de turnos
					//TurnoNegocio turnoNegocio = new TurnoNegocio();
					//aux.Turnos = new List<Turno>();
					//if(turnoNegocio.listarFiltradoPaciente(aux).Count() > 0)
					//	aux.Turnos = turnoNegocio.listarFiltradoPaciente(aux);


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
        public List<Paciente> listarFiltradoPaciente(Paciente paciente)
        {

            AccesoDatos datos = new AccesoDatos();
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            List<Paciente> lista = new List<Paciente>();
            try
            {
                datos.setearConsulta("select Nombre, Apellido, Dni, FechaNacimiento, Telefono, Email from Paciente where id = @IdPaciente");
				datos.setearParametro("@IdPaciente", paciente.Id);
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
        public void Agregar(Paciente nuevo)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Insert into Paciente Values(@Nombre, @Apellido, @Dni, @FechaNacimiento, @Telefono, @Email)");
				datos.setearParametro("@Nombre", nuevo.Nombre);
				datos.setearParametro("@Apellido", nuevo.Apellido);
				datos.setearParametro("@Dni", nuevo.Dni);
				datos.setearParametro("@FechaNacimiento", nuevo.FechaNacimiento);
				datos.setearParametro("@Telefono", nuevo.Telefono);
				datos.setearParametro("@Email", nuevo.Email);
				datos.ejecutarAccion();
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
		public void Modificar(Paciente nuevo)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Update Paciente Set Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Email = @Email where Id = @Id");
				datos.setearParametro("@Nombre", nuevo.Nombre);
				datos.setearParametro("@Apellido", nuevo.Apellido);
				datos.setearParametro("@Dni", nuevo.Dni);
				datos.setearParametro("@FechaNacimiento", nuevo.FechaNacimiento);
				datos.setearParametro("@Telefono", nuevo.Telefono);
				datos.setearParametro("@Email", nuevo.Email);
				datos.setearParametro("@Id", nuevo.Id);
				datos.ejecutarAccion();
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
