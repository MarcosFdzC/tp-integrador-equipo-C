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
		public List<Paciente> Listar()
		{
			Paciente paciente = new Paciente();
			AccesoDatos datos = new AccesoDatos();
			TurnoNegocio turnoNegocio = new TurnoNegocio();
			List<Paciente> lista = new List<Paciente>();
			try
			{
				datos.setearConsulta("");
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
