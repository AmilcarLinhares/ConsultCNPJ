using CNPJ.App.Interfaces;
using CNPJ.App.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CNPJ.App.AppServices
{
    public class ConsultAppService : IConsultAppService
    {
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

            var count = model.CnpjWsList.Count();
            count++;
            for (int i = count; i <= model.QtCnpj; i++)
            {
                model.CnpjWsList.Add(new CnpjVM(i));
            };


            return model;
        }

        public CnpjWsVM Search(CnpjWsVM model)
        {

            return model;
        }

    }
}
