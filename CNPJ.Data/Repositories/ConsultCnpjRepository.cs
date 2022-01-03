using CNPJ.Data.Context;
using CNPJ.Domain.DTO;
using CNPJ.Domain.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPJ.Data.Extension;


namespace CNPJ.Data.Repositories
{
    public class ConsultCnpjRepository : IConsultCnpjRepository, IDisposable
    {
        private readonly ConsultCnpjDbContext db;

        public ConsultCnpjRepository(ConsultCnpjDbContext ConsultCnpjDbContext)
        {
            this.db = ConsultCnpjDbContext;
        }

        public async Task<bool> AddEmpresaAsync(ResponseApiWsDTO model)
        {
            await db.AddAsync(model);

            return true;
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
