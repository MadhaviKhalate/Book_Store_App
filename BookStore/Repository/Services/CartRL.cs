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
    public class CartRL : ICartRL
    {
        private readonly IConfiguration configuration;
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        SqlConnection sqlConnection;
        SqlDataReader sqlDataReader;
        List<CartPostModel> cart = new List<CartPostModel>();
        public CartModel AddCart(CartModel cart, int UserId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddToCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", cart.BookId);
                    cmd.Parameters.AddWithValue("@BookQuantity ", cart.BookQuantity);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return cart;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CartModel UpdateCart(int CartId, CartModel cart, int UserId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartId ", CartId);
                    cmd.Parameters.AddWithValue("@BookQuantity ", cart.BookQuantity);
                    cmd.Parameters.AddWithValue("@BookId ", cart.BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return cart;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string RemoveCart(int CartId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("RemoveCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartId ", CartId);


                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return "Remove Cart";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CartPostModel> GetCart(int UserID)
        {
            sqlConnection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();
                    String query = "SELECT CartID, Book_Quantity, BookId FROM CartTable WHERE UserId = '" + UserID + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        cart.Add(new CartPostModel()
                        {
                            CartID = sqlDataReader["CartId"].ToString(),
                            CartQty = sqlDataReader["Book_Quantity"].ToString(),
                            BookID = sqlDataReader["BookId"].ToString()

                        });
                    }
                    return cart;
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
