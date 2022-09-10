using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL wishList;
        public WishListBL(IWishListRL wishList)
        {
            this.wishList = wishList;
        }

        public WishListModel AddWishList(WishListModel wish, int UserId)
        {
            try
            {
                return this.wishList.AddWishList(wish, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string DeleteWishList(int WishListId, int UserId)
        {
            try
            {
                return this.wishList.DeleteWishList(WishListId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<WishListModel> GetWishlist(int UserID)
        {
            try
            {
                return wishList.GetWishlist(UserID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
