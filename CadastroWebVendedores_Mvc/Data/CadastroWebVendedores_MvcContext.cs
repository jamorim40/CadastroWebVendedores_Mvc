using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroWebVendedores_Mvc.Models;

namespace CadastroWebVendedores_Mvc.Data
{
    public class CadastroWebVendedores_MvcContext : DbContext
    {
        public CadastroWebVendedores_MvcContext (DbContextOptions<CadastroWebVendedores_MvcContext> options)
            : base(options)
        {
        }


        // Define entidades DbSet (propriedades para cada modelo)
        public DbSet<Departamento> Departamento { get; set; } = default!;
        public DbSet<Vendedor> Vendedor { get; set; } = default!;
        public DbSet<RegistroDeVendas> RegistroDeVendas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroDeVendas>()
                .HasOne(rv => rv.Vendedor)
                .WithMany(v => v.Vendas) // <-- nome certo da coleção
                .HasForeignKey(rv => rv.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}
