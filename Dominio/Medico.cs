using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Dominio
{
    public class Medico
    {
        //Id, Nombre, Apellido, Turnos(lista), Especialidades(lista), TurnosTrabajo(Lista)
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Turno> Turnos { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public List<TurnoTrabajo> TrunosTrabajo { get; set; }

    }
}
