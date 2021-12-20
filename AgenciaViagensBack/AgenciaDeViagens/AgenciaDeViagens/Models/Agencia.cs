using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Models
{
    public class Agencia
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Passaporte { get; set; }
        [Required]
        public string PrecoPromo { get; set; }
        [Required]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public int DestinoID { get; set; }
        public Destino Destino { get; set; }
    }
}
