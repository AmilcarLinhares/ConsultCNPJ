﻿using System;
using System.Threading.Tasks;

namespace CNPJ.Domain.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        Task BeginTransactionConsultCnpjAsync();
        Task CommitConsultCnpjAsync();
        Task RollbackConsultCnpjAsync();
        Task SaveChangesConsultCnpjAsync();
        Task<DateTime> GetDateTimeFromConsultCnpjDBAsync();

    }
}
