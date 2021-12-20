using AgenciaDeViagens.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Data
{
    public class AgenciaDeViagensContext : DbContext
    {
        public AgenciaDeViagensContext(DbContextOptions<AgenciaDeViagensContext> options) :
          base(options)
        { }

        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Destino> Destino { get; set; }
    }
}
