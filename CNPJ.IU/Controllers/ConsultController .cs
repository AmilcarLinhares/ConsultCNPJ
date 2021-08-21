using CNPJ.App.Interfaces;
using CNPJ.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CNPJ.IU.Controllers
{
    public class ConsultController : Controller
    {
        private readonly ILogger<ConsultController> _logger;
        private readonly IConsultAppService _consultAppService;

        public ConsultController(
            ILogger<ConsultController> logger,
            IConsultAppService consultAppService)
        {
            _logger = logger;
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

        public IActionResult Search(CnpjWsVM model)
        {
            model = _consultAppService.Search(model);

            return View(model);
        }

    }
}
