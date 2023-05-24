using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class OrderRepository:IOrder
    {
        private CarDbContext _orderDb;
        public OrderRepository(CarDbContext orderDbContext)
        {
            _orderDb = orderDbContext;
        }



        #region  Adding Order
        public async Task<bool> AddOrder(Order order)
        {
            try
            {
                if (order == null)
                {
                    return false;
                }
                await _orderDb.Orders.AddAsync(order);
                await _orderDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Order

        #region Delete Order
        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var order = await _orderDb.Orders.FindAsync(id);
                if (order == null)
                    return false;
                _orderDb.Orders.Remove(order);
                _orderDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Order

        #region GetAll Order
        public async Task<List<Order>> GetAllOrder()
        {
            try
            {
                var temp = await _orderDb.Orders.ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Order

        #region Get Order
        public async Task<Order> GetOrder(int id)
        {
            Order order;
            try
            {
                order = await _orderDb.Orders.FindAsync(id);
                if (order != null)
                {
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return order;
        }
        #endregion Get Order

        #region Update Order
        public async Task<bool> UpdateOrder(Order order)
        {
            try
            {
                var order1 = await _orderDb.Orders.AsNoTracking().FirstOrDefaultAsync(u => u.Id == order.Id);
                if (order1 == null)
                    return false;
                _orderDb.Orders.Update(order);
                await _orderDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Order



    }
}
