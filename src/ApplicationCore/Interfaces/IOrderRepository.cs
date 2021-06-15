using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{

    public interface IOrderRepository : IAsyncRepository<Order>
    {
        /// <summary>
        /// I always want to fetch the items when I get an order
        /// </summary>
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
