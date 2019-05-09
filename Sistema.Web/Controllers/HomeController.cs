using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema.Business;
using Sistema.Entity;

namespace Sistema.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //List<Pessoa> pessoas = new PessoaBusiness().Listar();
            List<Pessoa> pessoas = (List<Pessoa>)Session["listPessoas"];
            if (pessoas == null)
            {
                pessoas = new List<Pessoa>();
            }
            return View(pessoas);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Incluir(Pessoa pessoa)
        {
            //var result = new PessoaBusiness().Inserir(pessoa);

            List<Pessoa> pessoas =(List<Pessoa>)Session["listPessoas"];
            if (pessoas == null)
            {
                pessoas = new List<Pessoa>();
            }

            if (pessoa.Id > 0)
            {
                //var atualiza = new PessoaBusiness().Atualizar(pessoa);
                pessoas.Remove(pessoas.Where(x => x.Id == pessoa.Id).FirstOrDefault());
            }
            else
            {
                int proxId = pessoas.Count > 0 ? pessoas.Max(x => x.Id) : 0;
                pessoa.Id = proxId + 1;
            }

            int idade = DateTime.Now.Year - pessoa.DataNascimento.Year;
            if (DateTime.Now.Month < pessoa.DataNascimento.Month || (DateTime.Now.Month == pessoa.DataNascimento.Month && DateTime.Now.Day < pessoa.DataNascimento.Day))
                idade--;

            pessoa.Idade = idade;

            pessoas.Add(pessoa);

            Session["listPessoas"] = pessoas;

            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            //var result = new PessoaBusiness().Deletar(new Pessoa { Id = id });

            List<Pessoa> pessoas = (List<Pessoa>)Session["listPessoas"];

            pessoas.Remove(pessoas.Where(x => x.Id == id).FirstOrDefault());

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            //var result = new PessoaBusiness().Selecionar(id);

            List<Pessoa> pessoas = (List<Pessoa>)Session["listPessoas"];

            Pessoa pessoa = pessoas.Where(x => x.Id == id).FirstOrDefault();

            return View("Cadastrar", pessoa);
        }

        public ActionResult SelecionarMaiorvalor()
        { 
            //List<Pessoa> pessoas = new PessoaBusiness().Listar();
            List<Pessoa> pessoas = (List<Pessoa>)Session["listPessoas"];
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