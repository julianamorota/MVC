using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using LocadoraDigitalMVC.Entities;

namespace LocadoraDigitalMVC.Repository.EntityFramework.Context
{
    
    public class LocadoraDigitalMVCContext : DbContext
    {
        
        public LocadoraDigitalMVCContext()
            : base("name=LocadoraDigitalMVCConnectionString")
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Devolucao> Devolucoes { get; set; }

    }
}
