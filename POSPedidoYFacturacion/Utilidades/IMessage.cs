using System;
using System.Threading.Tasks;

namespace POSPedidoYFacturacion.Utilidades
{
    public interface IMessage
    {
        Task Alert(string message);
        Task Error(string message);
        Task Success(string message);
        Task<int> Dialog(string titulo, string opcion1, string opcion2);

        // Task<bool> Confirm(string message, string textoConfirmar, string textoDenegar);
        Task<bool> Confirm(string message);
    }
}
