using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DataObjects
{
    public abstract class Conexao : IDisposable
    {
        protected bool Disposed { get; private set; }

        private string stringConexao = "";

        protected SqlConnection conexao
        {
            get
            {
                var conn = new SqlConnection(stringConexao);
                conn.Open();
                return conn;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }
    }
}
