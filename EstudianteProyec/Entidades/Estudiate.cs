using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudianteProyec.Entidades
{
    public class Estudiante
    {

        public int EstudianteID { get; set; }

        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento  { get; set; }
        
        public int Sexo { get; set; }
        public decimal Balance { get; set; }
        public object  Celular { get; internal set; }

        public Estudiante()
        {
            EstudianteID = 0;
            Matricula = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Email = string.Empty;
            FechaNacimiento = DateTime.Now;
            Sexo = 0;
            Balance = 0;


        }





    }
}
