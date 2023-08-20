using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class DepartamentoController : Controller
    {
        private static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento()
            {
                DepartamentoID = 1,
                Nome = "Administrativo",
            },
            new Departamento()
            {
                DepartamentoID = 2,
                Nome = "Financeiro",
            },
            new Departamento()
            {
                DepartamentoID = 3,
                Nome = "Pessoal"
            },
            new Departamento()
            {
                DepartamentoID = 4,
                Nome = "Comercial"
            },
            new Departamento()
            {
                DepartamentoID = 5,
                Nome = "Marketing"
            }
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento departamento)
        {
            departamento.DepartamentoID = departamentos.Select(i => i.DepartamentoID).Max
                () + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoID ==
                departamento.DepartamentoID).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        public IActionResult Delete(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoID ==
                departamento.DepartamentoID).First());
            return RedirectToAction("Index");
        }
    }
}