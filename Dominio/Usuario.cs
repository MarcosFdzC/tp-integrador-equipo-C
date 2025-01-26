using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum Rol
    {
        Medico = 1,
        Recepcionista = 2,
        Admin = 3
    }
    public class Usuario
    {
        //Usuario: Id, Nombre, Pass, Rol(Admin, Medico, Recepcionista), Estado

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; }//activo/inactivo

    }
}
