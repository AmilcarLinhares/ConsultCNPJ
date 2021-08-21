using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPJ.App.ViewModels
{
    public class CnpjWsVM
    {
        public int QtCnpj { get; set; }
        public List<CnpjVM> CnpjWsList { get; set; }
    }
}
