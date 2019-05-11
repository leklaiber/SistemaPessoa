using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema.Facade;
using Sistema.Entity;

namespace Sistema.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Pessoa> pessoas = PessoaFacade.Listar();
            if (pessoas == null)
                pessoas = new List<Pessoa>();

            return View(pessoas);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Incluir(Pessoa pessoa)
        {
            var result = PessoaFacade.Inserir(pessoa);

            if (pessoa.Id > 0)
            {
                bool atualizou = PessoaFacade.Atualizar(pessoa);
                if (!atualizou)
                {
                    // mostra erro
                }
            }
            else
            {
                bool inseriu = PessoaFacade.Inserir(pessoa);
                if (!inseriu)
                {
                    // mostra erro
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            var result = PessoaFacade.Deletar(new Pessoa { Id = id });

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var pessoa = PessoaFacade.Selecionar(id);
          
            return View("Cadastrar", pessoa);
        }

        public ActionResult SelecionarMaiorvalor()
        { 
            List<Pessoa> pessoas = PessoaFacade.Listar();
            if (pessoas == null)
            {
                pessoas = new List<Pessoa>();
            }
            decimal maiorSaldo = pessoas.Max(c => c.Dinheiro);
            Pessoa pessoa = pessoas.Where(x => x.Dinheiro == maiorSaldo).FirstOrDefault();

            return View("Cadastrar", pessoa);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}