using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Models
{
    public class Destino
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string Horario { get; set; }
    }
}
