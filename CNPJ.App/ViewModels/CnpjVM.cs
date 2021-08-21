using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPJ.App.ViewModels
{
    public class CnpjVM
    {

        public int? IdCnpjSearch { get; set; }
        public string CnpjSearch { get; set; }
        public CnpjVM(int? idCnpjSearch)
        {
            IdCnpjSearch = idCnpjSearch;
        }
        public CnpjVM()
        {
        }


    }
}
