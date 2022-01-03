using CNPJ.App.Interfaces;
using CNPJ.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNPJ.IU.Controllers
{
    public class ConsultController : Controller
    {
        private readonly IConsultAppService _consultAppService;

        public ConsultController(
            IConsultAppService consultAppService)
        {
            this._consultAppService = consultAppService;
        }

        public IActionResult Consult()
        {
            var model = _consultAppService.Index();

            return View(model);
        }


        public IActionResult Cnpj(CnpjWsVM model)
        {
            model = _consultAppService.AddCnpj(model);

            return View(model);
        }

        public async Task<IActionResult> Search(CnpjWsVM model)
        {
            var result = await _consultAppService.Search(model);

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddCnpj(string cnpj)
        {
            var result = await _consultAppService.AddDb(cnpj);

            return new JsonResult(new { Result = result });
        }
    }
}
