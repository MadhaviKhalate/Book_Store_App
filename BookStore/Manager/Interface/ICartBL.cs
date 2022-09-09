using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface ICartBL
    {
        public CartModel AddCart(CartModel cart, int UserId);

    }
}
