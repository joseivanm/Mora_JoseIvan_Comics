using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public interface IPedidoRepository
    {
        int GetTotalPedidosUltimoMes(int usuarioId);

        int GetProductosConStockBajo();

        decimal GetImportePedidosHoy();

        decimal GetImportePedidosHoyUsuario(int usuarioId);
        string GetTotalPedidosUltimoMes(string id);
        List<KeyValuePair<string, double>> GetVentasPorEditorial();
        List<int> GetPedidosPorEmpleadoUltimoAno();
    }
}
