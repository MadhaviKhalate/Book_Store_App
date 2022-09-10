using Microsoft.Extensions.Configuration;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Services
{
    public class WishListRL : IWishListRL
    {
        private readonly IConfiguration configuration;
        public WishListRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        SqlConnection sqlConnection;
        SqlDataReader sqlDataReader;
        List<WishListModel> wishlist = new List<WishListModel>();

        public WishListModel AddWishList(WishListModel wish, int UserId)
        {
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("AddWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", wish.BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return wish;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string DeleteWishList(int WishListId, int UserId)
        {
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
              
                    if (result != 0)
                    {
                        return "Delete WishList";
                    }
                    else
                    {
                        return null;
                    }
                }
            
            catch (Exception)
            {

                throw;
            }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public IEnumerable<WishListModel> GetWishlist(int UserID)
        {
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();
                    String query = "SELECT WishListId, BookId FROM Wishlist WHERE UserId = '" + UserID + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist.Add(new WishListModel()
                        {
                            WishListId = sqlDataReader["WishListId"].ToString(),
                            BookId = sqlDataReader["BookId"].ToString()

                        });
                    }
                    return wishlist;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
        }

    }
}
