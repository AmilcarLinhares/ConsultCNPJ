using AutoMapper;
using CNPJ.App.Interfaces;
using CNPJ.App.ViewModels;
using CNPJ.Domain.DTO;
using CNPJ.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNPJ.App.AppServices
{
    public class ConsultAppService : IConsultAppService
    {
        private readonly ISearchCnpjWsAPIService _searchCnpjWsAPIService;
        private readonly IMapper _mapper;

        public ConsultAppService(
            ISearchCnpjWsAPIService searchCnpjWsAPIService,
            IMapper mapper)
        {
            this._searchCnpjWsAPIService = searchCnpjWsAPIService;
            this._mapper = mapper;
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
            var modelDTO = _mapper.Map<List<CnpjVM>, List<CnpjApiDTO>>(model.CnpjWsList);
            var modelApiDTO = await _searchCnpjWsAPIService.GetCnpjApiAsync(modelDTO);

            var modelApiVM = _mapper.Map<List<ResponseApiWsDTO>,
                                         List<ResponseApiWsVM>>(modelApiDTO);
            return modelApiVM;
        }

    }
}
