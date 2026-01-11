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

        public DbSet<CadastroWebVendedores_Mvc.Models.Departamento> Departamento { get; set; } = default!;
    }
}
