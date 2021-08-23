using CNPJ.Domain.Interfaces;
using CNPJ.Data.Extension;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CNPJ.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConsultCnpjDbContext _consultCnpjDbContext;

        public UnitOfWork(ConsultCnpjDbContext consultCnpjDbContext)
        {
            this._consultCnpjDbContext = consultCnpjDbContext;
        }

        public async Task BeginTransactionConsultCnpjAsync()
        {
            if (_consultCnpjDbContext.Database.CurrentTransaction == null)
                await _consultCnpjDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitConsultCnpjAsync()
        {
            if (_consultCnpjDbContext.Database.CurrentTransaction != null)
                await _consultCnpjDbContext.Database.CurrentTransaction.CommitAsync();
        }

        public async Task RollbackConsultCnpjAsync()
        {
            if (_consultCnpjDbContext.Database.CurrentTransaction != null)
                await _consultCnpjDbContext.Database.CurrentTransaction.RollbackAsync();
        }

        public async Task SaveChangesConsultCnpjAsync()
        {
            await _consultCnpjDbContext.SaveChangesAsync();
        }

        public async Task<DateTime> GetDateTimeFromConsultCnpjDBAsync()
        {
            return await _consultCnpjDbContext.Database.GetDbConnection()
                .QueryFirstAsync<DateTime>("select getdate()", transaction: _consultCnpjDbContext.Database.CurrentTransaction.GetTransaction());
        }
    }
}
