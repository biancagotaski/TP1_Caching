using DevTrends.MvcDonutCaching;
using FirstApplication.Models;
using FirstApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PessoaController : Controller
    {
        [OutputCache(Duration = 20, VaryByParam = "none")]
        public ActionResult Index()
        {
            var repository = new ListaRepository();

            var pessoas = repository.GetAllPessoas();

            ViewBag.checkbox = DateTime.Now.ToString();

            return View(
                    pessoas.Select(p => new PessoaViewModel()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Sobrenome = p.Sobrenome,
                        Nascimento = p.Nascimento,
                        Email = p.Email,
                        IsChecked = false
                    })
                );
        }

        public ActionResult ListaSelecao()
        {
            var repository = new ListaRepository();
            IEnumerable<PessoaViewModel> pessoas = null;

            if (Session["friendsList"] != null)
                pessoas = (IEnumerable<PessoaViewModel>)Session["friendsList"];
            else
                pessoas = repository.GetAllPessoas().Select(p => new PessoaViewModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Sobrenome = p.Sobrenome,
                    Nascimento = p.Nascimento,
                    Email = p.Email,
                    IsChecked = false
                });

            return View(pessoas);
            //return ViewBag.checkbox = //variavel que retorna o valor da checkbox;
        }

        [HttpPost]
        public ActionResult Select(IEnumerable<PessoaViewModel> pessoas)
        {
            var repository = new ListaRepository();
            Session["friendsList"] = pessoas;

            if (Session["friendsList"] != null)
                pessoas = (IEnumerable<PessoaViewModel>)Session["friendsList"];
            else
                pessoas = repository.GetAllPessoas().Select(p => new PessoaViewModel()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Sobrenome = p.Sobrenome,
                    Nascimento = p.Nascimento,
                    Email = p.Email,
                    IsChecked = false
                });

            return View(pessoas);
        }

        //------------------------------------------------------------------------------------//
        [DonutOutputCache(Duration = 30)]
        public ActionResult About()
        {
            ViewBag.CurrentDataTimeMessage = DateTime.Now.ToString();

            return View();
        }

        public ActionResult SempreAtualiza()
        {
            ViewBag.CurrentDataTimeMessage = DateTime.Now.ToString();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.CurrentDataTimeMessage = DateTime.Now.ToString();

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public ActionResult CarregaNovoFluxo()
        {
            ViewBag.CurrentDataTimeMessage = DateTime.Now.ToString();
            return View();
        }
    }
}