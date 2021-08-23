using CNPJ.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNPJ.App.Interfaces
{
    public interface IConsultAppService
    {
        CnpjWsVM Index();
        CnpjWsVM AddCnpj(CnpjWsVM model);
        Task<List<ResponseApiWsVM>> Search(CnpjWsVM model);
        Task<bool> AddDb(string cnpj);
    }
}
