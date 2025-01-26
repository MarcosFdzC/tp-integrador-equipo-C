using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoTurno
    {
        Nuevo = 1,
        Reprogramado = 2,
        Cerrado = 3,
        Cancelado = 4,
        NoAsistio = 5,
    }
    public class Turno
    {
        //Turno: Id, Paciente, Medico, Especialidad, FechaHora, Observaciones, Estado
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observaciones { get; set; }
        public EstadoTurno Estado { get; set; }

    }
}
