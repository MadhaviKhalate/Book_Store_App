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
    public class OrderRL : IOrderRL
    {
        public IConfiguration configuration { get; }
        SqlConnection sqlConnection;
        public OrderRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool AddOrder(OrderModel order, int UserId)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("dbo.AddOrder", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@OrderQty", order.OrderQty);
                    sqlCommand.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    sqlCommand.Parameters.AddWithValue("@AddressId", order.AddressId);
                    sqlCommand.Parameters.AddWithValue("@BookId", order.BookId);
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);

                    var result = sqlCommand.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public bool DeleteOrder(int OrderId)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("dbo.RemoveOrder", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@OrderId", OrderId);
                    var result = sqlCommand.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
}
