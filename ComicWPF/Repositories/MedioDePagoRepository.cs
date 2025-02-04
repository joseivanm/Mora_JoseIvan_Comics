using ComicWPF.Models;
using Entidades;
using System.Collections.Generic;
using Ventas;

namespace ComicWPF.Repositories
{
    public class MedioDePagoRepository : IMedioDePagoRepository 
    {
        public List<MedioDePago> MediosDePago()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                return ventasADO.ListarMediosDePago();
            }
        }
    }
}
