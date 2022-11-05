using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IOrderBL
    {
        public bool AddOrder(OrderModel order, int UserId);
        public bool DeleteOrder(int OrderId);
        public IEnumerable<GetOrderModel> GetAllOrders();

    }
}
