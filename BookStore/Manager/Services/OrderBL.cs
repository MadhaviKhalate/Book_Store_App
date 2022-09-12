using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class OrderBL : IOrderBL
    {
        private IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public bool AddOrder(OrderModel order, int UserId)
        {
            try
            {
                return this.orderRL.AddOrder(order, UserId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool DeleteOrder(int OrderId)
        {
            try
            {
                return this.orderRL.DeleteOrder(OrderId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
