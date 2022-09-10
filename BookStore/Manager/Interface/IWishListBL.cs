using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IWishListBL
    {
        public WishListModel AddWishList(WishListModel wish, int UserId);
        public string DeleteWishList(int WishListId, int UserId);
        public IEnumerable<WishListModel> GetWishlist(int UserID);

    }
}
