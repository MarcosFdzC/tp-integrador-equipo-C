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
			Turno aux = new Turno();
			try
			{
				datos.setearConsulta("select * from Turno");
				while (datos.Lector.Read())
				{
					aux.Paciente = new Paciente();
					aux.Paciente.Id = (int)datos.Lector["Id"];
					aux.
				}
				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{

			}
        }
    }
}
