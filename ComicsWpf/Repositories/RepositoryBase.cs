using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ventas;
using System.Drawing.Text;
using Microsoft.Data.SqlClient;

namespace LoginComicsWpf.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Serve=(local): Database:Comics; Integrated Security=true";
        }
        protected new SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
