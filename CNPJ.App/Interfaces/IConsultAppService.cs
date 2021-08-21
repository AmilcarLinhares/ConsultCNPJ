using CNPJ.App.ViewModels;

namespace CNPJ.App.Interfaces
{
    public interface IConsultAppService
    {
        CnpjWsVM Index();
        CnpjWsVM AddCnpj(CnpjWsVM model);
        CnpjWsVM Search(CnpjWsVM model);
    }
}
