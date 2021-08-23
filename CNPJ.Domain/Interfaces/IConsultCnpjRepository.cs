﻿using CNPJ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPJ.Domain.Interfaces
{
    public interface IConsultCnpjRepository
    {
        Task<bool> AddAtivPrincipalAsync(ResponseApApiWsDTO model);
        Task<bool> AddAtivSecundariaAsync(ResponseAsApiWsDTO model);
        Task<bool> AddDiretorAsync(ResponseQsaApiWsDTO model);
        Task<bool> AddEmpresaAsync(ResponseApiWsDTO model);
    }
}
