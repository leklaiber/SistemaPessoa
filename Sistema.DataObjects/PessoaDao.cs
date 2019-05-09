using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entity;
using Dapper;
using System.Data.SqlClient;

namespace Sistema.DataObjects
{
    public class PessoaDao : Conexao
    {
        public Pessoa Selecionar(int id)
        {
            using (var conexao = base.conexao)
            {


                Pessoa pessoa = conexao.Query<Pessoa>("SELECT * FROM tbPessoa WHERE Id = @Id", new { Id = id }).FirstOrDefault();
                return pessoa;
            }
        }

        public bool Inserir(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("insert into tbPessoa (Nome, DataNascimento, Idade, Dinheiro)");
                query.AppendLine("VALUES (@Nome, @DataNascimento, @Idade, @Dinheiro)");

                SqlCommand cmd = new SqlCommand(query.ToString(), conexao);
                cmd.Parameters.AddWithValue("Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("DataNascimento", pessoa.DataNascimento);
                cmd.Parameters.AddWithValue("Idade", pessoa.Idade);
                cmd.Parameters.AddWithValue("Dinheiro", pessoa.Dinheiro);
                
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Atualizar(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                var result = conexao.Execute("UPDATE tbPessoa SET Nome = @Nome, Idade = @Idade, Dinheiro = @Dinheiro WHERE Id = @id", pessoa);
                return result > 0;
            }
        }

        public bool Deletar(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                var result = conexao.Execute("DELETE tbPessoa WHERE Id = @id", pessoa);
                return result > 0;
            }
        }

        public List<Pessoa> Listar()
        {
            using (var conexao = base.conexao)
            {
                List<Pessoa> pessoas = conexao.Query<Pessoa>("SELECT * FROM tbPessoa").ToList();
                return pessoas;
            }
        }
    }
}
