using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entity;
using Dapper;

namespace Sistema.DataObjects
{
    public class PessoaDao : Conexao
    {
        public Pessoa Selecionar(int id)
        {
            using (var conexao = base.conectar())
            {
                Pessoa pessoa = conexao.Query<Pessoa>("SELECT * FROM tbPessoa WHERE Id = @Id", new { Id = id }).FirstOrDefault();
                return pessoa;
            }
        }

        public bool Inserir(Pessoa pessoa)
        {
            using (var conexao = base.conectar())
            {
                var result = conexao.Execute("INSERT INTO tbPessoa (Nome, Idade, Dinheiro) VALUES (@Nome, @Idade, @Dinheiro)", pessoa);
                return result > 0;
            }
        }

        public bool Atualizar(Pessoa pessoa)
        {
            using (var conexao = base.conectar())
            {
                var result = conexao.Execute("UPDATE tbPessoa SET Nome = @Nome, Idade = @Idade, Dinheiro = @Dinheiro WHERE Id = @id", pessoa);
                return result > 0;
            }
        }

        public bool Deletar(Pessoa pessoa)
        {
            using (var conexao = base.conectar())
            {
                var result = conexao.Execute("DELETE tbPessoa WHERE Id = @id", pessoa);
                return result > 0;
            }
        }

        public List<Pessoa> Listar()
        {
            using (var conexao = base.conectar())
            {
                List<Pessoa> pessoas = conexao.Query<Pessoa>("SELECT * FROM tbPessoa").ToList();
                return pessoas;
            }
        }
    }
}
