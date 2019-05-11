using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema.Facade;
using Sistema.Entity;

namespace Sistema.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CadastroPessoa()
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Leandro";
            pessoa.DataNascimento = Convert.ToDateTime("18/11/1996");
            pessoa.Idade = 22;
            pessoa.Dinheiro = 500;

            var retorno = PessoaFacade.Inserir(pessoa);

            Assert.AreEqual(retorno, true);
        }
    }
}
