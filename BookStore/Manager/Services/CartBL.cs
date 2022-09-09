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
        public CartModel UpdateCart(int CartId, CartModel cart, int UserId)
        {
            try
            {
                return this.cartRL.UpdateCart(CartId, cart, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string RemoveCart(int CartId)
        {
            try
            {
                return this.cartRL.RemoveCart(CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CartPostModel> GetCart(int UserID)
        {
            try
            {
                return cartRL.GetCart(UserID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
