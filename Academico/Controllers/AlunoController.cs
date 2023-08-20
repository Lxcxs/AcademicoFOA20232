using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static IList<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                AlunoID = 1,
                Nome = "Lucas Cupertino",
                Matricula = "202110508"
            },
            new Aluno()
            {
                AlunoID = 2,
                Nome = "Flavio Antonio",
                Matricula = "202010439"
            }
        };
        public IActionResult Index()
        {
            return View(alunos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            aluno.AlunoID = alunos.Select(i => i.AlunoID).Max
                () + 1;
            alunos.Add(aluno);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            return View(alunos.Where(i => i.AlunoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            alunos.Remove(alunos.Where(i => i.AlunoID ==
                aluno.AlunoID).First());
            alunos.Add(aluno);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(alunos.Where(i => i.AlunoID == id).First());
        }
        public IActionResult Delete(long id)
        {
            return View(alunos.Where(i => i.AlunoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Aluno aluno)
        {
            alunos.Remove(alunos.Where(i => i.AlunoID ==
                aluno.AlunoID).First());
            return RedirectToAction("Index");
        }
    }
}
