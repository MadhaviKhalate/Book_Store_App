using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICartRL
    {
        public CartModel AddCart(CartModel cart, int UserId);
        public CartModel UpdateCart(int CartId, CartModel cart, int UserId);

        public string RemoveCart(int CartId);
        public IEnumerable<CartPostModel> GetCart(int UserID);


    }
}
