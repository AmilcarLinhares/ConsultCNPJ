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

                var resultEmpresa = await _consultCnpjRepository.AddEmpresaAsync(model);

                if (resultEmpresa)
                {
                    foreach (var qsa in model.qsa)
                    {
                        await _consultCnpjRepository.AddDiretorAsync(qsa);
                    }

                    foreach (var ap in model.atividade_principal)
                    {
                        await _consultCnpjRepository.AddAtivPrincipalAsync(ap);
                    }

                    foreach (var se in model.atividades_secundarias)
                    {
                        await _consultCnpjRepository.AddAtivSecundariaAsync(se);
                    }

                    await _uow.SaveChangesConsultCnpjAsync();
                    await _uow.CommitConsultCnpjAsync();
                    
                    return true;
                }
                else
                {
                    await _uow.RollbackConsultCnpjAsync();
                    return false;
                }

            }
            catch (Exception ex)
            {
                await _uow.RollbackConsultCnpjAsync();
                return false;
            }
        }
    }
}
