﻿using Sistema.DataObjects;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Business
{
    public class PessoaBusiness
    {
        public Pessoa Selecionar(int id)
        {
            try
            {
                if (id == 0)
                {
                    return null;
                }

                var pessoa = new PessoaDao().Selecionar(id);
                return pessoa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Inserir(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return false;
                }

                return new PessoaDao().Inserir(pessoa);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return false;
                }

                return new PessoaDao().Atualizar(pessoa);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Deletar(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return false;
                }

                return new PessoaDao().Deletar(pessoa);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Pessoa> Listar()
        {
            try
            {
                return new PessoaDao().Listar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
