using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class instituicaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
