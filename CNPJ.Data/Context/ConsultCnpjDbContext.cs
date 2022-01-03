using CNPJ.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPJ.Data.Context
{
    public class ConsultCnpjDbContext : DbContext
    {
        public ConsultCnpjDbContext()
        {
        }

        public ConsultCnpjDbContext(DbContextOptions<ConsultCnpjDbContext> options) 
            : base(options) 
        { }

        public DbSet<ResponseApiWsDTO> Empresa { get; set; }
        public DbSet<ResponseApApiWsDTO> AtividadePrincipal { get; set; }
        public DbSet<ResponseAsApiWsDTO> AtividadeSecundaria { get; set; }
        public DbSet<ResponseQsaApiWsDTO> Diretor { get; set; }

    }
}
