using ProductsModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductsDAL
{
    public class ProductsDB : IProductsDB
    {
        public List<Product> GetProducts(Product searchCriteria, string searchOption)
        {
            List<Product> products = new List<Product>();

            string connectionString = ConfigurationManager.ConnectionStrings["ProductsDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("usp_SearchProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductName", searchCriteria.ProductName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Size", searchCriteria.Size ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", searchCriteria.Price ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MfgDate", searchCriteria.MfgDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", searchCriteria.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SearchChoice", searchOption ?? (object)DBNull.Value);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ProductName = reader["ProductName"].ToString(),
                                Size = reader["Size"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                MfgDate = Convert.ToDateTime(reader["MfgDate"]),
                                Category = reader["Category"].ToString()
                            });
                        }
                    }
                }
            }
            return products;
        }
    }
}
