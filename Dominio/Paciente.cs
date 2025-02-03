using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente
    {
        //Id, Nom,Apell, Dni, FechaNacimiento, Telefono, Email, Turnos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public List<Turno> Turnos { get; set; }
    }
}
