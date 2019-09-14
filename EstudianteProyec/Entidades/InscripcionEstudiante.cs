using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudianteProyec.Entidades
{
   public class InscripcionEstudiante
    {
        [Key]
        public int InscripcionId { get; set; }

        public DateTime FechaIns { get; set; }

        public int EstudianteId { get; set; }

        public string Comentario { get; set; }

        public decimal Monto { get; set; }

        public decimal Deposito{ get; set; }

        public decimal Balance { get; set; }




        public InscripcionEstudiante()
        {
            InscripcionId = 0;
            FechaIns = DateTime.Now;
            EstudianteId = 0;
            Comentario = string.Empty;
            Monto = 0;
            Deposito = 0;
            Balance = 0;


        }
    }
}
