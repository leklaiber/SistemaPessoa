using Sistema.Business;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Facade
{
    public static class PessoaFacade
    {
        public static Pessoa Selecionar(int id)
        {
            return new PessoaBusiness().Selecionar(id);
        }

        public static bool Inserir(Pessoa pessoa)
        {
            return new PessoaBusiness().Inserir(pessoa);
        }

        public static bool Atualizar(Pessoa pessoa)
        {
            return new PessoaBusiness().Atualizar(pessoa);
        }

        public static bool Deletar(Pessoa pessoa)
        {
            return new PessoaBusiness().Deletar(pessoa);
        }

        public static List<Pessoa> Listar()
        {
            return new PessoaBusiness().Listar();
        }
    }
}
