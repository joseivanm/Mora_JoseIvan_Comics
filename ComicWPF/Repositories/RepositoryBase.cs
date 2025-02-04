using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;
using Entidades;
using Ventas;

namespace ComicWPF.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
            
        }
        public List<MedioDePago> MediosDePago()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                List<MedioDePago> medioDePagos = ventasADO.ListarMediosDePago();
                return medioDePagos;

            }
        }

    }
}
