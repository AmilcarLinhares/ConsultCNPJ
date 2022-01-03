using CNPJ.Domain.DTO;
using CNPJ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CNPJ.Domain.Services
{
    public class AddDbService : IAddDbService
    {
        private readonly IConsultCnpjRepository _consultCnpjRepository;
        private readonly IUnitOfWork _uow;

        public AddDbService(IConsultCnpjRepository consultCnpjRepository
                           , IUnitOfWork uow)
        {
            this._consultCnpjRepository = consultCnpjRepository;
            this._uow = uow;
        }

        public async Task<bool> AddEmpresa(ResponseApiWsDTO model)
        {
            try
            {
                await _uow.BeginTransactionConsultCnpjAsync();

                var result = await _consultCnpjRepository.AddEmpresaAsync(model);

                await _uow.SaveChangesConsultCnpjAsync();
                await _uow.CommitConsultCnpjAsync();

                return result;
            }
            catch (Exception)
            {
                await _uow.RollbackConsultCnpjAsync();
                return false;
            }
        }
    }
}
