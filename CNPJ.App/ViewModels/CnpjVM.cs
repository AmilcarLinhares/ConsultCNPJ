using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPJ.App.ViewModels
{
    public class CnpjVM
    {

        public int? IdCnpjSearch { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ!")]
        public string CnpjSearch { get; set; }
        public string Erro { get; set; }
        public CnpjVM(int? idCnpjSearch)
        {
            IdCnpjSearch = idCnpjSearch;
        }
        public CnpjVM()
        {
        }


    }
}
