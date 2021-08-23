using AutoMapper;
using CNPJ.App.Interfaces;
using CNPJ.App.ViewModels;
using CNPJ.Domain.DTO;
using CNPJ.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CNPJ.App.AppServices
{
    public class ConsultAppService : IConsultAppService
    {
        private readonly ISearchCnpjWsAPIService _searchCnpjWsAPIService;
        private readonly IMapper _mapper;
        private readonly IAddDbService _addDbService;

        public ConsultAppService(
            ISearchCnpjWsAPIService searchCnpjWsAPIService,
            IMapper mapper,
            IAddDbService addDbService)
        {
            this._searchCnpjWsAPIService = searchCnpjWsAPIService;
            this._mapper = mapper;
            this._addDbService = addDbService;
        }

        public CnpjWsVM Index()
        {
            var model = new CnpjWsVM
            {
                QtCnpj = 1
            };
            model.CnpjWsList = new List<CnpjVM>
            {
                new CnpjVM(1)
            };

            return model;
        }
        public CnpjWsVM AddCnpj(CnpjWsVM model)
        {
            if (model.QtCnpj >= 11)
            {
                model.QtCnpj = 10;
                return model;
            }

            var count = model.CnpjWsList.Count;
            count++;
            for (int i = count; i <= model.QtCnpj; i++)
            {
                model.CnpjWsList.Add(new CnpjVM(i));
            };


            return model;
        }

        public async Task<List<ResponseApiWsVM>> Search(CnpjWsVM model)
        {
            model = ValidationCNPJ(model);

            var modelDTO = _mapper.Map<List<CnpjVM>, List<CnpjApiDTO>>(model.CnpjWsList);
            var modelApiDTO = await _searchCnpjWsAPIService.GetCnpjApiAsync(modelDTO);

            var modelApiVM = _mapper.Map<List<ResponseApiWsDTO>,
                                         List<ResponseApiWsVM>>(modelApiDTO);
            return modelApiVM;
        }

        private CnpjWsVM ValidationCNPJ(CnpjWsVM model)
        {
            foreach (var item in model.CnpjWsList)
            {
                var cnpj = item.CnpjSearch;
                if (!string.IsNullOrWhiteSpace(cnpj))
                {
                    cnpj = cnpj.Trim();
                    cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                    if (!Regex.IsMatch(cnpj, @"^[0-9]+$"))
                    {
                        item.Erro = "CNPJ Invalido!";
                    }
                    else if (!IsCnpj(cnpj))
                    {
                        item.Erro = "CNPJ Invalido!";
                    }
                    else
                    {
                        item.CnpjSearch = cnpj;
                    }
                }
                else
                {
                    item.Erro = "CNPJ em Branco!";
                }


            }

            return model;
        }

        private bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public async Task<bool> AddDb(string cnpj)
        {
            CnpjWsVM model = new CnpjWsVM
            {
                CnpjWsList = new List<CnpjVM>(),
                QtCnpj = 1
            };

            model.CnpjWsList.Add(new CnpjVM(1));
            model.CnpjWsList[0].CnpjSearch = cnpj;

            var resultApi = await Search(model);

            var modelDTO = _mapper.Map<ResponseApiWsVM, ResponseApiWsDTO>(resultApi[0]);

            var result = await _addDbService.AddEmpresa(modelDTO);

            return result;
        }
    }
}
