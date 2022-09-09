using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public CartModel AddCart(CartModel cart, int UserId)
        {
            try
            {
                return this.cartRL.AddCart(cart, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
